namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static GymApp.Common.EntityValidationConstants.Exercise;

    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(ExecutionMaxLength)]
        public string Execution { get; set; } = null!;
        [Required]
        [MaxLength(BenefitMaxLength)]
        public string Benefit { get; set; } = null!;
        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;
        public int CategoryId { get; set; }
        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
        public ICollection<ApplicationUserExercise> UsersExercises { get; set; } = new List<ApplicationUserExercise>();
    }
}
