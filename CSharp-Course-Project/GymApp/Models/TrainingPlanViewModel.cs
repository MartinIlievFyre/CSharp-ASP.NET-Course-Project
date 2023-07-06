namespace GymApp.Models
{
    using System.ComponentModel.DataAnnotations;

    using GymApp.Data.Models;

    using static GymApp.Data.ValidationConstants.Note;

    public class TrainingPlanViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public IdentityUserExercise User { get; set; } = null!;
    }
}
