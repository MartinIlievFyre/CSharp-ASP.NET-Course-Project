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
        public int Calories { get; set; }

        [Required]
        public double Carbs { get; set; }

        [Required]
        public double Fat { get; set; }

        [Required]
        public double Protein { get; set; }

        public ICollection<IdentityUserFood> UsersFood { get; set; } = new List<IdentityUserFood>();
    }
}
