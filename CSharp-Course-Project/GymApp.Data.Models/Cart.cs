using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Data.Models
{
    public class Cart
    {
        public Cart()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;

            AccessoryCartItems = new HashSet<AccessoryCartItem>();
            SupplementCartItems = new HashSet<SupplementCartItem>();
            WearCartItems = new HashSet<WearCartItem>();
        }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<AccessoryCartItem> AccessoryCartItems { get; set; }
        public virtual ICollection<SupplementCartItem> SupplementCartItems { get; set; }
        public virtual ICollection<WearCartItem> WearCartItems { get; set; }

    }
}

