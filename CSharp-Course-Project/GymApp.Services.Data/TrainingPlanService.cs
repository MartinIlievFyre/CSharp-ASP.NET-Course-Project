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
        public async Task<List<TrainingPlanViewModel>> GetAllTrainingPlanByCategoryId(string categoryId)
        {
            Category? category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == int.Parse(categoryId));
            if (category == null)
            {
                throw new ArgumentException(ThereIsNoCategoryWithThisId);
            }

            List<TrainingPlanViewModel> trainingPlans = await dbContext
                .TrainingPlans
                .Where(tp => tp.CategoryId == int.Parse(categoryId))
                .Select(tp => new TrainingPlanViewModel()
                {
                    Id = tp.Id,
                    Name = tp.Name,
                    Description = tp.Description,
                    Category = tp.Category.Name

                })
                .ToListAsync();

            if (trainingPlans.Count == 0)
            {
                throw new ArgumentException(ThereAreNoTrainingPlansWithThisCategoryId);
            }
            return trainingPlans;
        }

    }
}
