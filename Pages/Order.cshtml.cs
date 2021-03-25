using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bakery.RazorPages.Client.Models;
using Bakery.RazorPages.Client.Services;

namespace Bakery.RazorPages.Client.Pages
{
    public class OrderModel : PageModel
    {
        private readonly ProductService _productService;
        
        private readonly OrderService _orderService;
        
        public OrderModel(ProductService productService, OrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }
            
        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }

        public Product Product { get; set;}

        [BindProperty]
        public Order Order{ get; set;}

        public async Task OnGetAsync()
        {
            Product = await _productService.GetProductById(Id);
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            Product = await _productService.GetProductById(Id);
            if(ModelState.IsValid) 
            {
                await _orderService.CreateOrder(Order);
                return RedirectToPage("OrderSuccess");
            }
            return Page();
        }
    }
}