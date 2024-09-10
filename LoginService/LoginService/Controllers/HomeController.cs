using LoginService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
          // return View("Views\\Login\\UserLogin.cshtml");
            //return View(@"D:\OneDrive - EasyRewardz Software Services Private Limited\Practice\ProgramsInCSharp\LoginService\LoginService\LoginService\Views\Login\UserLogin.cshtml");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
