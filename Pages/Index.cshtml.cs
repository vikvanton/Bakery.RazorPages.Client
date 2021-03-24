using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Bakery.RazorPages.Client.Services;
using Bakery.RazorPages.Client.Models;

namespace Bakery.RazorPages.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProductService _productService;

        public IEnumerable<Product> Products { get; private set; } = new List<Product>();

        public Product FeaturedProduct { get; set; }

        public IndexModel(ProductService productService)
        {
            _productService = productService;
        }

        public async Task OnGetAsync()
        {
            Products = await _productService.GetProducts();
            FeaturedProduct = Products.ElementAt(new Random().Next(Products.Count<Product>()));
        }

    }
}
