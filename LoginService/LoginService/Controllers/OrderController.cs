using LoginService.Models;
using LoginService.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace LoginService.Controllers
{
    public class OrderController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<OrderController> _logger;
        private readonly DBClient _dBClient;

        public OrderController(IConfiguration configuration, ILogger<OrderController> logger, DBClient dBClient)
        {
            _configuration = configuration;
            _logger = logger;
            _dBClient = dBClient;
        }

        [HttpGet("[controller]/GetUserOrderDetails")]
        public async Task<IActionResult> GetUserOrderDetails( ) {
            APIResponse aPIResponse = null;
           string userId = "4dea54f3b8256fc55fd8be55c3a7121f827f79a9c27566c72039b5187fcb340b";
            try
            {
                aPIResponse = await _dBClient.GetAllOrdersByUserIdAsync(userId).ConfigureAwait(false);
                _logger.LogInformation($"GetUserOrderDetails : Response : {JsonConvert.SerializeObject(aPIResponse)}");
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "OrderController : GetUserOrderDetails : Exception : ");
            }
            return View(aPIResponse?.OrderResponseByOrderId);
        }


    }
}
