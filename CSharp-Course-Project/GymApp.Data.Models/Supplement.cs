namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GymApp.Common.EntityValidationConstants.Supplement;
    public class Supplement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ManufacturerNameMaxLength)]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxlLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(BenefitsMaxLength)]
        public string Benefits { get; set; } = null!;

        [Required]
        [MaxLength(IngredientsMaxLength)]
        public string Ingredients { get; set; } = null!;
        [Required]
        [MaxLength(TypeMaxLength)]
        public string Type { get; set; } = null!;

        [Required]
        [Range(typeof(Decimal), PriceMin, PriceMax)]
        public decimal Price { get; set; }

    }
}
