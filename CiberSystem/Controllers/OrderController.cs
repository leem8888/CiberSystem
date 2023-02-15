using CiberSystem.EF;
using CiberSystem.Entities;
using CiberSystem.Models;
using CiberSystem.Models.Login;
using CiberSystem.Models.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CiberSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly CiBerDbContext _context;
        private readonly OrderModel _orderModel;
        private readonly IConfiguration _config;
        public OrderController(CiBerDbContext context, OrderModel orderModel, IConfiguration config)
        {
            _context = context;
            _orderModel = orderModel;
            _config = config;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {

            string cookieValueFromReq = Request.Cookies["_CiberUserLogin"];
            if (cookieValueFromReq != null)
            {
                var claim = ValidateToken(cookieValueFromReq);
                OrderViewItem item = new OrderViewItem();               
                item.NameCus = claim.Claims.SingleOrDefault(p => p.Type == "name")?.Value;
                int idCus = Int32.Parse(claim.Claims.SingleOrDefault(p => p.Type == "id")?.Value);
             
                //danh sach product cho popup
                item.Products = await _orderModel.GetAllProduct();

                // danh sách đơn hàng 
                item.Orders = await _orderModel.GetAllOrder(1,10000, idCus);
                return View(item);
            }
            return Redirect("/User/Login");

        }

        public async Task<IActionResult> AddOrder(AddOrderRequest request)
        {
            try
            {
                string cookieValueFromReq = Request.Cookies["_CiberUserLogin"];
                if (cookieValueFromReq != null)
                {
                    var claim = ValidateToken(cookieValueFromReq);
                    int id = Int32.Parse(claim.Claims.SingleOrDefault(p => p.Type == "id")?.Value);

                    if (!ModelState.IsValid)
                    {
                        return Json(new
                        {
                            error = true
                        });
                    }
                    //check tồn
                    int stock = await _orderModel.GetStockByProductId(request.idProduct);
                    if (request.amountOrder <= stock)
                    {
                        bool subtract = await _orderModel.SubtractByProductId(request.idProduct, request.amountOrder);
                        bool addOrder = await _orderModel.AddOrder(request.amountOrder, request.orderDate, request.idProduct, id);
                        return Json(new
                        {
                            error = false,
                            success = subtract
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            error = false,
                            success = false
                        });
                    }
                }
                return Redirect("/User/Login");
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = true
                });
            }
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _config["Tokens:Issuer"];
            validationParameters.ValidIssuer = _config["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }        
    }
}
