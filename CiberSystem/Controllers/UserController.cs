using CiberSystem.EF;
using CiberSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CiberSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly CiBerDbContext _context;
        public UserController(CiBerDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            var cate = _context.Categories.FirstOrDefault();
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            var cate = _context.Categories.FirstOrDefault();
            return View();
        }
        //public async Task<string> Authencate(LoginRequest request)
        //{
        //    var user = await _userManager.FindByNameAsync(request.UserName);
        //    if (user == null) return null;

        //    var result = await _signInManager.PasswordSignInAsync(user, request.Passwrod, request.RememberMe, true);
        //    if (!result.Succeeded)
        //    {
        //        return null;
        //    }
        //    var roles = await _userManager.GetRolesAsync(user);
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.Email,user.Email),
        //        new Claim(ClaimTypes.GivenName,user.FirstName),
        //        new Claim(ClaimTypes.Role, string.Join(";",roles))
        //    };
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(_config["Tokens:Issuer"],
        //        _config["Tokens:Issuer"],
        //        claims,
        //        expires: DateTime.Now.AddHours(3),
        //        signingCredentials: creds);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}
