namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GymApp.Data.ValidationConstants.Food;

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
        public int Carbs { get; set; }

        [Required]
        public int Fat { get; set; }

        [Required]
        public int Protein { get; set; }

        public ICollection<IdentityUserFood> UsersFood { get; set; } = new List<IdentityUserFood>();
    }
}
