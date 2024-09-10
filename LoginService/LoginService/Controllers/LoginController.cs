using LoginService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.CompilerServices;

namespace LoginService.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
             
        [HttpGet("[controller]/Register")]
        public IActionResult Register() 
        {
            return View();
        }


        [HttpPost("[controller]/UserRegister")]
        public IActionResult UserRegister(UserRegisterRequest userRegisterRequest) 
        {
            return Ok( new UserRegisterResponse() { Status = 100, Message="Success" });
        }


        [HttpGet("[controller]/UserLogin")]
        public IActionResult UserLogin ()
        {
            
            return View();
           
        }


        [HttpPost("[controller]/UserSignIn")]
        public IActionResult UserSignIn(UserLoginRequest userLoginRequest)
        {
            return Ok( new { Status = 100, Message = "Success" });
        }
    }
}
