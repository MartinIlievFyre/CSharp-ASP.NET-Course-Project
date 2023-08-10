namespace GymApp.Services.Data.Interfaces
{
    using GymApp.ViewModels;
    using GymApp.Data.Models;

    public interface ITrainingPlanService
    {
        Task<List<TrainingPlanViewModel>> GetAllTrainingPlanByCategoryId(string categoryId);
    }
}
