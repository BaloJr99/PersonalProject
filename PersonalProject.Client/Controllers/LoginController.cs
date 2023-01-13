using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalProject.Business.Interfaces;
using PersonalProject.Data.DTO;

namespace PersonalProject.Client.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IAuthenticateService _authenticate;
        private readonly IJwtUtils _jwtUtils;

        public LoginController(ILogger<LoginController> logger, IAuthenticateService authenticate, IJwtUtils jwtUtils)
        {
            _logger = logger;
            _authenticate = authenticate;
            _jwtUtils = jwtUtils;
        }        

        public IActionResult Index(UserDTO userLogin)
        {
            if(User.Identity.IsAuthenticated){
                return RedirectToAction("Index", "Home"); 
            }
            return View();
        }   

        [HttpPost]
        public async Task<IActionResult> LoginUser(UserDTO userLogin)
        {
            var user = await _authenticate.Authenticate(userLogin);
            if(user != null){
                var token = _jwtUtils.GenerateToken(user);
                if(token != null){
                    HttpContext.Session.SetString("Token", token);
                    HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions(){HttpOnly = true, Expires = DateTime.Now.AddDays(7),  });
                }else{
                    return Ok(new { success  = false });
                }
            }else{
                return Ok(new { success  = false });
            }
            return Ok(new { success  = true });
        }

        [HttpPost]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("X-Access-Token");
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(UserDTO userDTO)
        {
            var user = await _authenticate.CreateUser(userDTO);
            var token = _jwtUtils.GenerateToken(user);
            if(token != null)
                HttpContext.Session.SetString("Token", token);
                Response.Cookies.Append("X-Access-Token", token, new CookieOptions(){ HttpOnly = true, SameSite = SameSiteMode.Strict });
            return Ok(new {success = true });
        }

        public IActionResult SignIn()
        {
            if(User.Identity.IsAuthenticated){
                return RedirectToAction("Index", "Home"); 
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}