using Bakery.RazorPages.Client.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bakery.RazorPages.Client.Services
{
    public class OrderService
    {
        private readonly string _route;

        private readonly HttpClient _httpClient;

        public OrderService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _route = configuration["OrderService:ControllerRoute"];
        }

        public Task CreateOrder(Order order) =>
            _httpClient.PostAsJsonAsync(_route, order);
    }
}