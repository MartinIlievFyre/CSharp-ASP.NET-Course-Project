using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Data.Models
{
    public class WearCartItem
    {
        public WearCartItem()
        {
            Quantity = 1;
        }

        [ForeignKey(nameof(Wear))]
        public int WearId { get; set; }

        [Required]
        public Wear Wear { get; set; } = null!;

        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }

        [Required]
        public Cart Cart { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
