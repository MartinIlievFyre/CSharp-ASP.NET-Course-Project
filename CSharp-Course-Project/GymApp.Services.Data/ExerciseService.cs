namespace GymApp.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using GymApp.Data;
    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.ExceptionMessages;
    using GymApp.Migrations;

    public class ExerciseService : IExerciseService
    {
        private readonly GymAppDbContext dbContext;
        public ExerciseService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<ExerciseViewModel>> GetAllExerciseViewModelsByCategoryIdAsync(string categoryId)
        {
            Category? category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == int.Parse(categoryId));
            if (category == null)
            {
                throw new ArgumentException(ThereIsNoCategoryWithThisId);
            }
            List<ExerciseViewModel> exercises = await dbContext
                .Exercises
                .Where(e => e.CategoryId == int.Parse(categoryId))
                .Select(e => new ExerciseViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Execution = e.Execution,
                    Benefit = e.Benefit,
                    Category = e.Category.Name,
                    ImageUrl = e.ImageUrl
                })
                .ToListAsync();
            if (exercises.Count == 0)
            {
                throw new ArgumentException(ThereAreNoExercisesWithThisCategoryId);
            }
            return exercises;
        }
        public async Task<ExerciseViewModel?> GetExerciseViewModelByIdAsync(string exerciseId)
        {
            ExerciseViewModel? exerciseViewModel = await dbContext
                .Exercises
                .Where(e => e.Id == int.Parse(exerciseId))
                .Select(e => new ExerciseViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Execution = e.Execution,
                    Benefit = e.Benefit,
                    Category = e.Category.Name,
                    ImageUrl = e.ImageUrl,
                })
                .FirstOrDefaultAsync();

            if (exerciseViewModel == null)
            {
                throw new ArgumentException(ThereIsNoExerciseWithThisId);
            }

            return exerciseViewModel;
        }

        public async Task<Exercise?> GetExerciseByIdAsync(int exerciseId)
        {
            Exercise? exercise = await dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId);

            if (exercise == null)
            {
                throw new ArgumentException(ThereIsNoExerciseWithThisId);
            }

            return exercise;
        }

        public async Task<List<ExerciseViewModel>> GetAllExerciseViewModelsByUserId(string? userId)
        {
            List<ExerciseViewModel> exercises = await dbContext
               .Exercises
               .Where(e => e.UsersExercises.Any(ue => ue.TrainingGuyId.ToString() == userId))
               .Select(e => new ExerciseViewModel()
               {
                   Id = e.Id,
                   Name = e.Name,
                   ImageUrl = e.ImageUrl,
                   Benefit = e.Benefit,
                   Execution = e.Execution,
                   Category = e.Category.Name
               })
               .ToListAsync();

            
            return exercises;
        }

        public async Task<List<ExerciseViewModel>> GetAllExerciseViewModelsByUserIdAndACategoryId(string categoryId, string? userId)
        {
            List<ExerciseViewModel> exercises = await dbContext
                    .Exercises
                    .Where(e => e.CategoryId == int.Parse(categoryId) && e.UsersExercises.Any(u => u.TrainingGuyId.ToString() == userId))
                    .Select(e => new ExerciseViewModel()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Execution = e.Execution,
                        Benefit = e.Benefit,
                        Category = e.Category.Name,
                        ImageUrl = e.ImageUrl
                    })
                    .ToListAsync();
            if (exercises.Count == 0)
            {
                throw new ArgumentException(NoExercisesAdded);
            }
            return exercises;
        }

        public async Task<ExerciseViewModel?> GetExerciseViewModelByIdAndUserIdAsync(string exerciseId, string? userId)
        {
            ExerciseViewModel? exercise = await dbContext
         .Exercises
         .Where(e => e.Id == int.Parse(exerciseId) && e.UsersExercises.Any(u => u.TrainingGuyId.ToString() == userId))
         .Select(e => new ExerciseViewModel()
         {
             Id = e.Id,
             Name = e.Name,
             Execution = e.Execution,
             Benefit = e.Benefit,
             Category = e.Category.Name,
             ImageUrl = e.ImageUrl,
         })
         .FirstOrDefaultAsync();
            if (exercise == null)
            {
                throw new ArgumentException(ThereIsNoExerciseWithThisExerciseIdAndUserId);
            }
            return exercise;
        }

        public async Task<ApplicationUserExercise> GetUserFromApplicationUserExerciseAsync(string? userId)
        {
            ApplicationUserExercise user = await dbContext.
                ApplicationUsersExercises.
                FirstAsync(u => u.TrainingGuyId.ToString() == userId);
            if (user == null)
            {
                throw new ArgumentException(ThereIsNoUserWithThisId);
            }
            return user;
        }

        public async Task<ApplicationUserExercise> GetExerciseByIdAndUserIdFromApplicationUserExerciseAsync(int exerciseId, string? userId)
        {
            ApplicationUserExercise? exercise = await dbContext
                .ApplicationUsersExercises
                .FirstOrDefaultAsync(ue => ue.ExerciseId == exerciseId && ue.TrainingGuyId.ToString() == userId);
            if (exercise == null) 
            {
                throw new ArgumentException(ThereIsNoExerciseWithThisExerciseIdAndUserId);
            }
            return exercise;
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

        public ExerciseDetailsViewModel CreateExerciseDetailsViewModel(ExerciseViewModel currentExercise, List<ExerciseViewModel> randomExercises)
        {
            ExerciseDetailsViewModel model = new ExerciseDetailsViewModel()
            {
                CurrentExercise = currentExercise,
                RandomExercises = randomExercises
            };
            if (model == null)
            {
                throw new ArgumentException();
            }
            return model;
        }

        public async Task CreateNewApplicationUserExerciseAsync(Exercise exercise, int id, Guid userGuidId)
        {
            exercise.UsersExercises.Add(new ApplicationUserExercise()
            {
                ExerciseId = id,
                TrainingGuyId = userGuidId
            });

            await dbContext.SaveChangesAsync();
            Task.Delay(1500).Wait();
        }

        public EditExerciseViewModel CreateEditExerciseViewModel(Exercise? exercise, IEnumerable<CategoryViewModel> categories)
        {
            EditExerciseViewModel model = new EditExerciseViewModel()
            {
                Id = exercise!.Id,
                Name = exercise.Name,
                Benefit = exercise.Benefit,
                Execution = exercise.Execution,
                ImageUrl = exercise.ImageUrl,
                CategoryId = exercise.CategoryId,
                Categories = (ICollection<CategoryViewModel>)categories
            };

            if (model == null)
            {
                throw new ArgumentException();
            }

            return model;
        }

        public async Task<List<int>> RandomExerciseIdsAsync(string id)
        {
            List<int> randomExercisesIds = await dbContext.Exercises
                 .Where(e => e.Id != int.Parse(id))
                 .Select(e => e.Id)
                 .OrderBy(x => Guid.NewGuid())
                 .Take(3)
                 .ToListAsync();

            if (randomExercisesIds.Count == 0)
            {
                throw new ArgumentException(RandomExercisesIdsAreNull);
            }
            return randomExercisesIds;
        }

        public async Task<List<ExerciseViewModel>> RandomExercisesWithIdsAsync(List<int> randomExercisesIds)
        {
            List<ExerciseViewModel> randomExercises = await dbContext.Exercises
                .Where(e => randomExercisesIds.Contains(e.Id))
                .Select(e => new ExerciseViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Category = e.Category.Name,
                    ImageUrl = e.ImageUrl
                })
                .ToListAsync();
            if (randomExercises.Count == 0)
            {
                throw new ArgumentException(RandomExercisesWithIdsAreNull);
            }
            return randomExercises;
        }


        public async Task<bool> IsExerciseWithThisIdExistInApplicationUserExerciseAsync(int exerciseId)
        {
            bool doesExercisesExist = await dbContext.ApplicationUsersExercises.AnyAsync(ue => ue.ExerciseId == exerciseId);
            return doesExercisesExist;
        }

        public bool IsThereExerciseWithThisUserInApplicationUserExercises(Exercise exercise, string? userId)
        {
            bool isThereExerciseWithThisUserId = exercise.UsersExercises.Any(ue => ue.TrainingGuyId.ToString() == userId);
            return isThereExerciseWithThisUserId;
        }


        public async Task EditingInformationAboutExerciseAsync(Exercise exercise, EditExerciseViewModel model)
        {
            exercise!.Name = model.Name;
            exercise.Benefit = model.Benefit;
            exercise.Execution = model.Execution;
            exercise.ImageUrl = model.ImageUrl;
            exercise.CategoryId = model.CategoryId;

            await dbContext.SaveChangesAsync();
        }


        public async Task RemoveExerciseFromMyFavoritesAsync(ApplicationUserExercise? exercise)
        {
            dbContext.ApplicationUsersExercises.Remove(exercise!);

            await dbContext.SaveChangesAsync();
        }
    }
}
