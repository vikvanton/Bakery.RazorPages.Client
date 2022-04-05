using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
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

        public Product Product { get; set;}

        [BindProperty]
        public Order Order{ get; set;}

        [BindProperty]
        [Display(Name = "Email")]
        [EmailAddress, Required]
        public string OrderEmail { get; set; }

        public async Task OnGetAsync(int id)
        {
            Product = await _productService.GetProductById(id);
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            Product = await _productService.GetProductById(id);
            if(ModelState.IsValid) 
            {
                Order.OrderPrice = Product.Price * Order.OrderQuantity;
                await _orderService.CreateOrder(Order);
                var body = $@"<p>Thank you, we have received your order for {Order.OrderQuantity} unit(s) of {Product.Name}!</p>
                            <p>Your address is: <br/>{Order.OrderShipping.Replace("\n", "<br/>")}</p>
                            Your total is {Order.OrderPrice}.
                            <p>We will contact you if we have questions about your order. Thanks!</p>";
                using(var smtp = new SmtpClient())
                {
                    var message = new MailMessage();
                    var credential = new NetworkCredential
                    {
                        UserName = " ",  // replace with valid value
                        Password = " "  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    message.To.Add(OrderEmail);
                    message.Subject = "Fourth Coffee - New Order";
                    message.Body = body;
                    message.IsBodyHtml = true;
                    message.From = new MailAddress(" "); // replace with valid value
                    await smtp.SendMailAsync(message);
                }        
                return RedirectToPage("OrderSuccess");
            }
            return Page();
        }
    }
}
