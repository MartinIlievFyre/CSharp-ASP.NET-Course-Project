using GymApp.Data.Models;

namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;
    using static GymApp.Common.EntityValidationConstants.Wear;


    public class Wear
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(typeof(Decimal), PriceMin, PriceMax)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(ImageUrMaxlLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ColorMaxLength)]
        public string Color { get; set; } = null!;

        public List<WearSizeCategory> Sizes { get; set; } = null!;

        public int WearCategoryId { get; set; }
        [Required]
        [ForeignKey(nameof(WearCategoryId))]
        public WearCategory WearCategory { get; set; } = null!;

        public ICollection<ApplicationUserWear> UsersClothing { get; set; } = new List<ApplicationUserWear>();
    }
}
