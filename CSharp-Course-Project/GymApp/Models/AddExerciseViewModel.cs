using GymApp.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static GymApp.Data.ValidationConstants.Exercise;
namespace GymApp.Models
{
    public class AddExerciseViewModel
    {
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
        [Required]
        public int CategoryId { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
