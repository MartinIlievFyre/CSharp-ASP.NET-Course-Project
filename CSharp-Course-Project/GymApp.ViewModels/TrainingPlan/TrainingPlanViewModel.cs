namespace GymApp.ViewModels
{
    using GymApp.Data.Models;

    public class TrainingPlanViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public ApplicationUserExercise User { get; set; } = null!;
    }
}
