using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string? Size { get; set; }
        [Required]
        public string Image { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!; // Wear, Accessory, Supplement

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal TotalPrice { get => Quantity * Price; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey(nameof(User))]
        [Required]
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;
    }
}
