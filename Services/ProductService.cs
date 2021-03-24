using Bakery.RazorPages.Client.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bakery.RazorPages.Client.Services
{
    public class ProductService
    {
        private readonly string _route;

        private readonly HttpClient _httpClient;

        public ProductService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _route = configuration["ProductService:ControllerRoute"];
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var response = await _httpClient.GetAsync(_route);
            response.EnsureSuccessStatusCode();

            var products = await response.Content.ReadAsAsync<IEnumerable<Product>>();

            return products;
        }

        public async Task<Product> GetProductById(int productId)
        {
            var response = await _httpClient.GetAsync($"{_route}/{productId}");
            response.EnsureSuccessStatusCode();

            var product = await response.Content.ReadAsAsync<Product>();

            return product;
        }
    }
}