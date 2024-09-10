using LoginService.Controllers;
using LoginService.Models;
using System.Net.Http.Headers;

namespace LoginService.Services
{
    public class DBClient
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<OrderController> _logger;
        private readonly HttpClient _httpClient;
        public DBClient(IConfiguration configuration, ILogger<OrderController> logger, HttpClient httpClient)
        {
            _configuration = configuration;
            _logger = logger;
            _httpClient = httpClient;
        }

        // Method to get list of orders by userId
        public async Task<APIResponse> GetAllOrdersByUserIdAsync(string userId)
        {
            _httpClient.BaseAddress = new Uri( @"https://localhost:7061/");
            _httpClient.DefaultRequestHeaders.Add("accept", "text/plain");
            var content = JsonContent.Create(new OrderRequestByOrderId { OrderId = userId });
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PostAsync("api/Order/GetOrderDetailByOrderIdAsync", content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response body to List<Order>
                var orders = await response.Content.ReadFromJsonAsync<APIResponse>();
                return orders ?? new APIResponse() { Status = 303,Message = "Client failure." };
            }
            else
            {
                // Handle error response (e.g., log it, throw exception, etc.)
                throw new HttpRequestException($"Error fetching orders: {response.StatusCode}");
            }
        }


    }
}
