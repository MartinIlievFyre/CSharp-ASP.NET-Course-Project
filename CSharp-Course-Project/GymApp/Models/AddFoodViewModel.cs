namespace GymApp.Models
{
    using System.ComponentModel.DataAnnotations;

    using GymApp.Data.Models;

    using static GymApp.Common.EntityValidationConstants.Food;

    public class AddFoodViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(typeof(int), CaloriesMax, CaloriesMax)]
        public int Calories { get; set; }

        [Required]
        [Range(typeof(int), CarbsMax, CarbsMax)]
        public double Carbs { get; set; }

        [Required]
        [Range(typeof(int), FatMax, FatMax)]
        public double Fat { get; set; }

        [Required]
        [Range(typeof(int), ProteinMax, ProteinMax)]
        public double Protein { get; set; }
    }
}
