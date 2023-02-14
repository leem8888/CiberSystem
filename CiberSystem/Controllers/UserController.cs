using CiberSystem.EF;
using CiberSystem.Models;
using CiberSystem.Models.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class UserController : Controller
    {
        private readonly CiBerDbContext _context;
        private readonly LoginModel _loginModel;
        private readonly IConfiguration _config;
        public UserController(CiBerDbContext context, LoginModel loginModel, IConfiguration config)
        {
            _context = context;
            _loginModel = loginModel;
            _config = config;
        }
        [HttpGet]
        public IActionResult Login()
        {
            var cate = _context.Categories.FirstOrDefault();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            var user = await _loginModel.FindByNameAsync(request.Phone);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Tài khoản không tồn tại");
                return View();
            }



            var result = await _loginModel.PasswordSignInAsync(user, request.Pass);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Nhập sai mật khẩu");
                return View();
            }


            var claims = new[]
            {
                new Claim("id",user.Id.ToString()),
                new Claim("phone",user.Phone),
                 new Claim("name",user.Name),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddHours(3);
            cookieOptions.Path = "/";
            Response.Cookies.Append("_CiberUserLogin", new JwtSecurityTokenHandler().WriteToken(token), cookieOptions);


            return Redirect("/Order/Index");
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
