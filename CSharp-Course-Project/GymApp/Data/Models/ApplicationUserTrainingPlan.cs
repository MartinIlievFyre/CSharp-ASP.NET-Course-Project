namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUserTrainingPlan
    {
        [Required]
        [ForeignKey(nameof(TrainingGuy))]
        public Guid TrainingGuyId { get; set; }
        public ApplicationUser TrainingGuy { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(TrainingPlan))]
        public int TrainingPlanId { get; set; }
        public TrainingPlan TrainingPlan { get; set; } = null!;

    }
}
