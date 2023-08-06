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

        public async Task<TrainingPlan> GetTrainingPlanByIdAsync(int trainingPlanId)
        {
            TrainingPlan? trainingPlan = await dbContext.TrainingPlans.FirstOrDefaultAsync(e => e.Id == trainingPlanId);

            if (trainingPlan == null)
            {
                throw new ArgumentException(ThereIsNoTrainingPlanWithThisId);
            }

            return trainingPlan;
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

        public EditTrainingPlanViewModel CreateEditTrainingPlanViewModel(TrainingPlan? trainingPlan, IEnumerable<CategoryViewModel> categories)
        {
            EditTrainingPlanViewModel model = new EditTrainingPlanViewModel()
            {
                Id = trainingPlan!.Id,
                Name = trainingPlan.Name,
                Description = trainingPlan.Description,
                CategoryId = trainingPlan.CategoryId,
                Categories = (ICollection<CategoryViewModel>)categories
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

        public async Task EditingInformationAboutTrainingPlanAsync(TrainingPlan trainingPlan, EditTrainingPlanViewModel model)
        {
            trainingPlan.Name = model.Name;
            trainingPlan.Description = model.Description;
            trainingPlan.CategoryId = model.CategoryId;

            await dbContext.SaveChangesAsync();
        }


    }
}
