namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GymApp.Common.EntityValidationConstants.Food;

    public class UserFood
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int Calories { get; set; }

        [Required]
        public double Carbs { get; set; }

        [Required]
        public double Fat { get; set; }

        [Required]
        public double Protein { get; set; }
        [Required]
        public int Grams { get; set; }

        public ICollection<ApplicationUserFood> UsersFood { get; set; } = new List<ApplicationUserFood>();
    }
}
