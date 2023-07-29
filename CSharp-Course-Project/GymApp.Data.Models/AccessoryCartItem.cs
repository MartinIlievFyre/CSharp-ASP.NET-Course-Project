using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Data.Models
{
    public class AccessoryCartItem
    {
        public AccessoryCartItem()
        {
            Quantity = 1;
        }

        [ForeignKey(nameof(Accessory))]
        public int AccessoryId { get; set; }

        [Required]
        public Accessory Accessory { get; set; } = null!;

        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }

        [Required]
        public Cart Cart { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
