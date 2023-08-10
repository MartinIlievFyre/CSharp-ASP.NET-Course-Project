using GymApp.Data;
using GymApp.Data.Models;
using GymApp.Services.Data.Interfaces;
using GymApp.ViewModels;
using GymApp.ViewModels.Accessory;
using GymApp.ViewModels.Clothing;
using GymApp.ViewModels.Supplement;
using GymApp.ViewModels.WearCategory;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using static GymApp.Common.ExceptionMessages;

using static GymApp.Common.GeneralApplicationConstants;
namespace GymApp.Services.Data
{
    public class AdminService : IAdminService
    {
        private readonly GymAppDbContext dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(GymAppDbContext dbContext, UserManager<ApplicationUser> _userManager)
        {
            this._userManager = _userManager;
            this.dbContext = dbContext;
        }
        //ACCESSORY
        public async Task DeleteAccessoryAsync(Accessory accessory)
        {
            dbContext.Accessories.Remove(accessory);
            await dbContext.SaveChangesAsync();
        }
        public async Task<Accessory> CreateAccessoryAsync(AddAccessoryViewModel model)
        {
            bool isExerciseExist = await dbContext.Accessories.AnyAsync(a => a.Name == model.Name);
            if (isExerciseExist)
            {
                throw new ArgumentException(ThereIsWearWithThisName);
            }
            Accessory accessory = new Accessory()
            {
                Name = model.Name,
                Price = model.Price,
                Manufacturer = model.Manufacturer,
                Benefits = model.Benefits,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Type = TypeProductAccessory
            };
            await dbContext.AddAsync(accessory);
            await dbContext.SaveChangesAsync();
            return accessory;
        }
        public async Task<Accessory> GetAccessoryByIdAsync(int accessoryId)
        {
            Accessory? accessory = await dbContext.Accessories.FirstOrDefaultAsync(e => e.Id == accessoryId);

            if (accessory == null)
            {
                throw new ArgumentException(ThereIsNoAccessoryWithThisId);
            }

            return accessory;
        }
        public AddAccessoryViewModel CreateAddAccessoryViewModel()
        {
            AddAccessoryViewModel model = new AddAccessoryViewModel();
            if (model == null)
            {
                throw new ArgumentException();
            }
            return model;
        }

        //SUPPLEMENT
        public async Task DeleteSupplementAsync(Supplement supplement)
        {
            dbContext.Supplements.Remove(supplement);
            await dbContext.SaveChangesAsync();
        }
        public async Task<Supplement> CreateSupplementAsync(AddSupplementViewModel model)
        {
            bool isExerciseExist = await dbContext.Supplements.AnyAsync(s => s.Name == model.Name);
            if (isExerciseExist)
            {
                throw new ArgumentException(ThereIsWearWithThisName);
            }
            Supplement supplement = new Supplement()
            {
                Name = model.Name,
                Price = model.Price,
                Manufacturer = model.Manufacturer,
                Benefits = model.Benefits,
                Description = model.Description,
                Ingredients = model.Ingredients,
                ImageUrl = model.ImageUrl,
                Type = TypeProductSupplement
            };
            await dbContext.AddAsync(supplement);
            await dbContext.SaveChangesAsync();
            return supplement;
        }
        public async Task<Supplement> GetSupplementByIdAsync(int supplementId)
        {
            Supplement? supplement = await dbContext.Supplements.FirstOrDefaultAsync(e => e.Id == supplementId);

            if (supplement == null)
            {
                throw new ArgumentException(ThereIsNoSupplementWithThisId);
            }

            return supplement;
        }
        public AddSupplementViewModel CreateAddSupplementViewModel()
        {
            AddSupplementViewModel model = new AddSupplementViewModel();
            if (model == null)
            {
                throw new ArgumentException();
            }
            return model;
        }
        public EditSupplementViewModel CreateEditSupplementViewModel(Supplement supplement)
        {
            EditSupplementViewModel model = new EditSupplementViewModel()
            {
                Id = supplement.Id,
                Name = supplement.Name,
                Description = supplement.Description,
                ImageUrl = supplement.ImageUrl,
                Ingredients = supplement.Ingredients,
                Benefits = supplement.Benefits,
                Manufacturer = supplement.Manufacturer,
                Price = supplement.Price
            };

            if (model == null)
            {
                throw new ArgumentException();
            }

            return model;
        }
        public async Task EditingInformationAboutSupplementAsync(Supplement supplement, EditSupplementViewModel model)
        {
            supplement.Name = model.Name;
            supplement.Description = model.Description;
            supplement.Price = model.Price;
            supplement.Manufacturer = model.Manufacturer;
            supplement.Benefits = model.Benefits;
            supplement.Ingredients = model.Ingredients;

            await dbContext.SaveChangesAsync();
        }
        //WEAR
        public async Task DeleteWearAsync(Wear wear)
        {
            dbContext.Clothes.Remove(wear);
            await dbContext.SaveChangesAsync();
        }
        public async Task<Wear> CreateWearAsync(AddWearViewModel model)
        {
            bool isExerciseExist = await dbContext.Clothes.AnyAsync(c => c.Name == model.Name);
            if (isExerciseExist)
            {
                throw new ArgumentException(ThereIsWearWithThisName);
            }
            Wear wear = new Wear()
            {
                Name = model.Name,
                Price = model.Price,
                Color = model.Color,
                WearCategoryId = model.CategoryId,
                Size = model.Size,
                Description = model.Description,
                Fabric = model.Fabric,
                ImageUrl = model.ImageUrl,
                Type = TypeProductWear
            };
            await dbContext.AddAsync(wear);
            await dbContext.SaveChangesAsync();
            return wear;
        }
        public async Task<Wear> GetWearByIdAsync(int wearId)
        {
            Wear? Wear = await dbContext.Clothes.FirstOrDefaultAsync(e => e.Id == wearId);

            if (Wear == null)
            {
                throw new ArgumentException(ThereIsNoWearWithThisId);
            }

            return Wear;
        }
        public AddWearViewModel CreateAddWearViewModel(List<WearCategoryViewModel> categories)
        {
            AddWearViewModel model = new AddWearViewModel()
            {
                WearCategories = categories
            };
            if (model == null)
            {
                throw new ArgumentException();
            }
            return model;
        }
        public EditWearViewModel CreateEditWearViewModel(Wear? wear, IEnumerable<WearCategoryViewModel> categories)
        {
            EditWearViewModel model = new EditWearViewModel()
            {
                Id = wear!.Id,
                Name = wear.Name,
                Description = wear.Description,
                Size = wear.Size,
                Color = wear.Color,
                Fabric = wear.Fabric,
                ImageUrl = wear.ImageUrl,
                Price = wear.Price,
                CategoryId = wear.WearCategoryId,
                WearCategories = (ICollection<WearCategoryViewModel>)categories
            };

            if (model == null)
            {
                throw new ArgumentException();
            }

            return model;
        }
        public async Task EditingInformationAboutWearAsync(Wear wear, EditWearViewModel model)
        {
            wear.Name = model.Name;
            wear.Description = model.Description;
            wear.Size = model.Size;
            wear.Color = model.Color;
            wear.Fabric = model.Fabric;
            wear.ImageUrl = model.ImageUrl;
            wear.Price = model.Price;
            wear.WearCategoryId = model.CategoryId;

            await dbContext.SaveChangesAsync();
        }

        //EXERCISE
        public async Task DeleteExerciseAsync(Exercise exercise)
        {
            dbContext.Exercises.Remove(exercise!);
            await dbContext.SaveChangesAsync();
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
        public async Task<Exercise?> GetExerciseByIdAsync(int exerciseId)
        {
            Exercise? exercise = await dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId);

            if (exercise == null)
            {
                throw new ArgumentException(ThereIsNoExerciseWithThisId);
            }

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
        public async Task EditingInformationAboutExerciseAsync(Exercise exercise, EditExerciseViewModel model)
        {
            exercise!.Name = model.Name;
            exercise.Benefit = model.Benefit;
            exercise.Execution = model.Execution;
            exercise.ImageUrl = model.ImageUrl;
            exercise.CategoryId = model.CategoryId;

            await dbContext.SaveChangesAsync();
        }

        //TRAINING PLAN
        public async Task DeleteTrainingPlanAsync(TrainingPlan trainingPlan)
        {
            dbContext.TrainingPlans.Remove(trainingPlan);
            await dbContext.SaveChangesAsync();
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
        public async Task EditingInformationAboutTrainingPlanAsync(TrainingPlan trainingPlan, EditTrainingPlanViewModel model)
        {
            trainingPlan.Name = model.Name;
            trainingPlan.Description = model.Description;
            trainingPlan.CategoryId = model.CategoryId;

            await dbContext.SaveChangesAsync();
        }

        //PANEL
        public async Task<List<ApplicationUser>> UsersListAsync()
        {
            List<ApplicationUser> users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<ApplicationUser> GetApplicationUserByIdAsync(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new ArgumentException(ThereIsNoUserWithThisId);
            }
            return user;
        }
        public async Task SoftDeletingUser(ApplicationUser user)
        {
            user.Name = "-_-";
            user.IsModerator = false;
            user.ProfilePicture = null;
            user.UserName = "-_-";
            user.NormalizedUserName = "-_-";
            user.EmailConfirmed = false;
            user.Email = "-_-";
            user.NormalizedEmail = "-_-";
            user.PasswordHash = null;
            user.SecurityStamp = null;
            user.IsDeleted = true;
            user.ConcurrencyStamp = null;
            user.PhoneNumber = null;
            user.PhoneNumberConfirmed= false;
            await dbContext.SaveChangesAsync();
        }
    }
}
