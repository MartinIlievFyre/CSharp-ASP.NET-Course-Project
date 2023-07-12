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
        public int Calories { get; set; }

        [Required]
        public double Carbs { get; set; }

        [Required]
        public double Fat { get; set; }

        [Required]
        public double Protein { get; set; }
    }
}
