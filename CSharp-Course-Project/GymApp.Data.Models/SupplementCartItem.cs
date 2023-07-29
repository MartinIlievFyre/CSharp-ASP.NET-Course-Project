using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Data.Models
{
    public class SupplementCartItem
    {
        public SupplementCartItem()
        {
            Quantity = 1;
        }

        [ForeignKey(nameof(Supplement))]
        public int SupplementId { get; set; }

        [Required]
        public Supplement Supplement { get; set; } = null!;

        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }

        [Required]
        public Cart Cart { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
