namespace GymApp.Data.Models
{
using System.ComponentModel.DataAnnotations;

    using static GymApp.Common.EntityValidationConstants.Category;
    public class Category
    {
        public Category()
        {
            IsDeleted = false;

            Exercises = new HashSet<Exercise>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
