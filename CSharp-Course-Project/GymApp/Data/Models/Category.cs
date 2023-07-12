namespace GymApp.Data.Models
{
using System.ComponentModel.DataAnnotations;

    using static GymApp.Common.EntityValidationConstants.Category;
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
