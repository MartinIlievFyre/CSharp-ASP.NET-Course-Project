namespace GymApp.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using GymApp.Data;
    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.ExceptionMessages;

    public class ExerciseService : IExerciseService
    {
        private readonly GymAppDbContext dbContext;
        public ExerciseService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Exercise> CreateExerciseAsync(AddExerciseViewModel model)
        {
            bool isExerciseExist = await dbContext.Exercises.AnyAsync(e => e.Name == model.Name);
            if (isExerciseExist)
            {
                throw new ArgumentException(ThereIsExerciseWithThisName);
            }
            Exercise exercise = new Exercise()
            {
                Name = model.Name,
                Execution = model.Execution,
                Benefit = model.Benefit,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            };
            await dbContext.AddAsync(exercise);
            await dbContext.SaveChangesAsync();
            return exercise;
        }

        public AddExerciseViewModel CreateAddExerciseViewModel(List<CategoryViewModel> categories)
        {
            AddExerciseViewModel model = new AddExerciseViewModel()
            {
                Categories = categories
            };
            if (model == null)
            {
                throw new ArgumentException();
            }
            return model;
        }
    }
}
