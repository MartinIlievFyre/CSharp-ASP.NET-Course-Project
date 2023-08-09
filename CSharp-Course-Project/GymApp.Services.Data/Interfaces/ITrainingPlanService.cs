namespace GymApp.Services.Data.Interfaces
{
    using GymApp.ViewModels;
    using GymApp.Data.Models;

    public interface ITrainingPlanService
    {
        AddTrainingPlanViewModel CreateAddTrainingPlanViewModel(List<CategoryViewModel> categories);
        Task<TrainingPlan> CreateTrainingPlanAsync(AddTrainingPlanViewModel model);
        Task<List<TrainingPlanViewModel>> GetAllTrainingPlanByCategoryId(string categoryId);
        Task<TrainingPlan> GetTrainingPlanByIdAsync(int trainingPlanId);
        EditTrainingPlanViewModel CreateEditTrainingPlanViewModel(TrainingPlan? trainingPlan, IEnumerable<CategoryViewModel> categories);
        Task EditingInformationAboutTrainingPlanAsync(TrainingPlan trainingPlan, EditTrainingPlanViewModel model);
        Task DeleteTrainingPlanAsync(TrainingPlan trainingPlan);
    }
}
