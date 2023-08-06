namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUserExercise
    {
        [Required]
        public Guid TrainingGuyId { get; set; }
        [ForeignKey(nameof(TrainingGuyId))]
        public ApplicationUser TrainingGuy { get; set; } = null!;
        [Required]
        public int ExerciseId { get; set; }
        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; } = null!;
    }
}
