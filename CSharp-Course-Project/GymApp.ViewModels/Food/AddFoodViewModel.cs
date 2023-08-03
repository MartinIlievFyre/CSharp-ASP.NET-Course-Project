namespace GymApp.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static GymApp.Common.EntityValidationConstants.Food;

    public class AddFoodViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(typeof(int), CaloriesMin, CaloriesMax)]
        public int Calories { get; set; }

        [Required]
        [Range(typeof(int), CarbsMin, CarbsMax)]
        public double Carbs { get; set; }

        [Required]
        [Range(typeof(int), FatMin, FatMax)]
        public double Fat { get; set; }

        [Required]
        [Range(typeof(int), ProteinMin, ProteinMax)]
        public double Protein { get; set; }
    }
}
