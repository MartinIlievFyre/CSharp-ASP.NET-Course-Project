using GymApp.Data.Models;

namespace GymApp.Models
{
    public class CartViewModel
    {
        public List<AccessoryCartItem>? CartItems { get; set; }
        public decimal GrandTotal { get; set; } 
    }
}
