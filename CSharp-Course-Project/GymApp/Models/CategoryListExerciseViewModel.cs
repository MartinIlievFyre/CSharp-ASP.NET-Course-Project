namespace GymApp.Models
{
    public class CategoryListExerciseViewModel
    {
        public ICollection<CategoryViewModel> Categories { get; set; } = null!;
        public ICollection<ExerciseViewModel> Exercises { get; set; } = null!;
    }
}
