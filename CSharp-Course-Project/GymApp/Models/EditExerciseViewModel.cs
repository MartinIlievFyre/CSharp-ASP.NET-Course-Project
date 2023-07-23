namespace GymApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GymApp.Common.EntityValidationConstants.Exercise;

    public class EditExerciseViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(ExecutionMaxLength, MinimumLength = ExecutionMinLength)]
        public string Execution { get; set; } = null!;
        [Required]
        [StringLength(BenefitMaxLength, MinimumLength = BenefitMinLength)]
        public string Benefit { get; set; } = null!;
        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;
        [Required]
        public int CategoryId { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

    }
}
