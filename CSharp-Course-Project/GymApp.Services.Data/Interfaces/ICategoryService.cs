namespace GymApp.Services.Data.Interfaces
{
    using GymApp.ViewModels;
    using GymApp.ViewModels.WearCategory;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();
        Task<ICollection<WearCategoryViewModel>> AllWearCategoriesAsync();
        Task<string> GetCategoryNameByCategoryIdAsync(int id);
        CategoryListViewModel CreateCategoryListViewModel(ICollection<CategoryViewModel> categories);
        WearCategoryListViewModel CreateWearCategoryListViewModel(ICollection<WearCategoryViewModel> categories);
        CategoryListExerciseViewModel CreateCategoryListExerciseViewModel(IEnumerable<CategoryViewModel> categories, List<ExerciseViewModel> exercises);
    }
}
