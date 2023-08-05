namespace GymApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using GymApp.Data;
    using GymApp.Data.Models;
    using GymApp.ViewModels;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.ExceptionMessages;

    public class TrainingPlanService : ITrainingPlanService
    {
        private readonly GymAppDbContext dbContext;
        public TrainingPlanService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public AddTrainingPlanViewModel CreateAddTrainingPlanViewModel(List<CategoryViewModel> categories)
        {
            AddTrainingPlanViewModel model = new AddTrainingPlanViewModel()
            {
                Categories = categories
            };
            if (model == null)
            {
                throw new ArgumentException();
            }
            return model;
        }

        public async Task<TrainingPlan> CreateTrainingPlanAsync(AddTrainingPlanViewModel model)
        {
            bool isTrainingPlanExist = await dbContext.TrainingPlans.AnyAsync(e => e.Name == model.Name);

            if (isTrainingPlanExist)
            {
                throw new ArgumentException(ThereIsTrainingPlanWithThisName);
            }
            TrainingPlan trainingPlan = new TrainingPlan()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId
            };
            await dbContext.AddAsync(trainingPlan);
            await dbContext.SaveChangesAsync();
            return trainingPlan;
        }
    }
}
