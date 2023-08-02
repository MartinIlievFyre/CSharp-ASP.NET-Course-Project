namespace GymApp.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using System.ComponentModel.DataAnnotations;

    using static GymApp.Common.EntityValidationConstants.TrainingPlan;
    public class EditTrainingPlanViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

    }
}
