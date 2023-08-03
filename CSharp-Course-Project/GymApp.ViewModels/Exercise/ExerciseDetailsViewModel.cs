namespace GymApp.ViewModels
{
    public class ExerciseDetailsViewModel
    {
        public ExerciseViewModel CurrentExercise { get; set; } = null!;
        public List<ExerciseViewModel> RandomExercises { get; set; } = null!;
    }
}
