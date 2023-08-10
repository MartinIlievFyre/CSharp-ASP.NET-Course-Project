namespace GymApp.ViewModels.Supplement
{
    using System.ComponentModel.DataAnnotations;

    using static GymApp.Common.EntityValidationConstants.Supplement;
    public class EditSupplementViewModel
    {
        
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ManufacturerNameMaxLength, MinimumLength = ManufacturerNameMinLength)]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(BenefitsMaxLength, MinimumLength = BenefitsMinLength)]
        public string Benefits { get; set; } = null!;
        [Required]
        [StringLength(IngredientsMaxLength, MinimumLength = IngredientsMinLength)]
        public string Ingredients { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxlLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range((typeof(Decimal)), PriceMin, PriceMax)]
        public decimal Price { get; set; }
    }
}
