using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string GuestName { get; set; }
        [Required]
        public string GuestEmail { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}