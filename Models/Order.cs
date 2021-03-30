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

        [Display(Name = "Shipping address")]
        [Required]
        public string OrderShipping { get; set; }

        [Required]
        public string OrderProduct { get; set; } 

        [Display(Name = "Quantity")]
        [Required]
        [Range(1,100)]
        public int OrderQuantity { get; set; } = 1;

        [Required]
        [Range(0.01, 9999.99)]
        public decimal OrderPrice { get; set; }

        [Required]
        public string OrderStatus {get; set; }
    }
}