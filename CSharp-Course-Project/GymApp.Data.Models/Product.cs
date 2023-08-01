namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static GymApp.Common.EntityValidationConstants.Product;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(SizeMaxLength)]
        public string? Size { get; set; }
        [Required]
        [MaxLength(ImageUrlMaxlLength)]
        public string Image { get; set; } = null!;

        [Required]
        [MaxLength(TypeMaxLength)]
        public string Type { get; set; } = null!; // Wear, Accessory, Supplement
        [Required]
        [Range(typeof(Decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(Decimal), TotalPriceMinValue, TotalPriceMaxValue)]
        public decimal TotalPrice { get => Quantity * Price; }

        [Required]
        [Range(typeof(int), QuantityMinValue, QuantityMaxValue)]
        public int Quantity { get; set; }

        [ForeignKey(nameof(User))]
        [Required]
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;
    }
}
