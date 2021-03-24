using System.ComponentModel.DataAnnotations;

namespace Bakery.RazorPages.Client.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Phone")]
        [Phone, Required]
        public string CustomerPhone { get; set; }

        [Display(Name = "Email")]
        [EmailAddress, Required]
        public string OrderEmail { get; set; }

        [Display(Name = "Shipping address")]
        [Required]
        public string OrderShipping { get; set; }

        [Display(Name = "Ordered product")]
        [Required]
        public string OrderProduct { get; set; } 

        [Display(Name = "Quantity")]
        [Required]
        public int OrderQuantity { get; set; } = 1;
    }
}