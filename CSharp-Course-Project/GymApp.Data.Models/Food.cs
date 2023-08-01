namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GymApp.Common.EntityValidationConstants.Food;

    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(typeof(int),CaloriesMax, CaloriesMax)]
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
        [Required]
        public int Grams = DefaultGrams;

    }
}
