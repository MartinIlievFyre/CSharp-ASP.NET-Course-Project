namespace GymApp.Services.Data.Interfaces
{
    using GymApp.ViewModels;
    using GymApp.Data.Models;

    public interface IExerciseService
    {
        AddExerciseViewModel CreateAddExerciseViewModel(List<CategoryViewModel> categories);
        Task<Exercise> CreateExerciseAsync(AddExerciseViewModel model);
        Task<List<ExerciseViewModel>> GetAllExerciseViewModelsByUserIdAndACategoryId(string categoryId, string? userId);
        Task<List<ExerciseViewModel>> GetAllExerciseViewModelsByUserId(string? userId);
        Task<List<ExerciseViewModel>> GetAllExerciseViewModelsByCategoryIdAsync(string categoryId);
        Task<ExerciseViewModel?> GetExerciseViewModelByIdAsync(string exerciseId);
        Task<ExerciseViewModel?> GetExerciseViewModelByIdAndUserIdAsync(string exerciseId, string? userId);

        Task<List<int>> RandomExerciseIdsAsync(string id);
        Task<List<ExerciseViewModel>> RandomExercisesWithIdsAsync(List<int> randomExercisesIds);
        ExerciseDetailsViewModel CreateExerciseDetailsViewModel(ExerciseViewModel currentExercise ,List<ExerciseViewModel> randomExercises);
        EditExerciseViewModel CreateEditExerciseViewModel(Exercise? exercise , IEnumerable<CategoryViewModel> categories);
        Task<Exercise?> GetExerciseByIdAsync(int exerciseId);
        Task<bool> IsExerciseWithThisIdExistInApplicationUserExerciseAsync(int exerciseId, Guid userGuyId);
        bool IsThereExerciseWithThisUserInApplicationUserExercises(Exercise exercise, string? userId);
        Task CreateNewApplicationUserExerciseAsync(Exercise exercise, int id, Guid userGuidId);
        Task EditingInformationAboutExerciseAsync(Exercise exercise, EditExerciseViewModel model);

        Task<ApplicationUserExercise> GetUserFromApplicationUserExerciseAsync(string? userId);
        Task<ApplicationUserExercise> GetExerciseByIdAndUserIdFromApplicationUserExerciseAsync(int exerciseId, string? userId);
        Task RemoveExerciseFromMyFavoritesAsync(ApplicationUserExercise? exercise);
        Task DeleteExerciseAsync(Exercise exercise);
    }

}
