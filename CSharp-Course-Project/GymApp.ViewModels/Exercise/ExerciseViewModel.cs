namespace GymApp.ViewModels
{
    using GymApp.Data.Models;

    public class ExerciseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Execution { get; set; } = null!;

        public string Benefit { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Category { get; set; } = null!;

        public ApplicationUserExercise User { get; set; } = null!;
    }
}
