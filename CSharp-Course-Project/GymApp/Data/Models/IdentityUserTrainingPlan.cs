namespace GymApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    public class IdentityUserTrainingPlan
    {
        [Required]
        public string TrainingGuyId { get; set; } = null!;
        [ForeignKey(nameof(TrainingGuyId))]
        public IdentityUser TrainingGuy { get; set; } = null!;
        [Required]
        public int TrainingPlanId { get; set; }
        [ForeignKey(nameof(TrainingPlanId))]
        public TrainingPlan TrainingPlan { get; set; } = null!;
    }
}
