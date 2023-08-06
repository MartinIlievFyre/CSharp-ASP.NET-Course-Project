namespace GymApp.Services.Data.Interfaces
{
    using GymApp.ViewModels;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();
        Task<ICollection<CategoryViewModel>> AllWearCategoriesAsync();
        Task<string> GetCategoryNameByCategoryIdAsync(int id);
        CategoryListViewModel CreateCategoryListViewModel(ICollection<CategoryViewModel> categories);
        CategoryListExerciseViewModel CreateCategoryListExerciseViewModel(IEnumerable<CategoryViewModel> categories, List<ExerciseViewModel> exercises);
    }
}
