using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymApp.Common.EntityValidationConstants.Accessory;
namespace GymApp.ViewModels.Supplement
{
    public class AddSupplementViewModel
    {

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
        [MaxLength(ImageUrlMaxlLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range((typeof(Decimal)), PriceMin, PriceMax)]
        public decimal Price { get; set; }
    }
}
