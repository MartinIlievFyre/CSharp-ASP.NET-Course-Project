namespace GymApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    using System.ComponentModel.DataAnnotations.Schema;

    using System.ComponentModel.DataAnnotations;
    public class IdentityUserExercise
    {
        [Required]
        public string TrainingGuyId { get; set; } = null!;
        [ForeignKey(nameof(TrainingGuyId))]
        public IdentityUser TrainingGuy { get; set; } = null!;
        [Required]
        public int ExerciseId { get; set; }
        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; } = null!;
    }
}
