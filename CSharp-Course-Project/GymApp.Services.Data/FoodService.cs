namespace GymApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using GymApp.Data;
    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.ExceptionMessages;

    public class FoodService : IFoodService
    {
        private readonly GymAppDbContext dbContext;
        public FoodService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Food> AllFoodsWithDefaultValuesByIdAsync(int foodId)
        {
            Food? food = await dbContext.Foods.FirstOrDefaultAsync(f => f.Id == foodId);
            if (food == null)
            {
                throw new ArgumentException(ThereIsNoFoodWithThisId);
            }
            return food;
        }

        public async Task<UserFood> AllUserFoodsByIdAsync(int foodId)
        {
            UserFood? food = await dbContext.UsersFoods.FirstOrDefaultAsync(f => f.Id == foodId);
            if (food == null)
            {
                throw new ArgumentException(ThereAreNoFoods);
            }
            return food;
        }

        public async Task<IEnumerable<FoodViewModel>> AllFoodsWithDefaultValuesAsync()
        {
            List<FoodViewModel> foods = await this.dbContext
                .Foods
                .Select(f => new FoodViewModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Calories = f.Calories,
                    Carbs = f.Carbs,
                    Fat = f.Fat,
                    Protein = f.Protein
                })
                .ToListAsync();
            
            return foods;
        }

        public async Task<IEnumerable<FoodViewModel>> AllUserFoodsByUserIdAsync(string? userId)
        {
            List<FoodViewModel> foods =
                await this.dbContext
                .UsersFoods
                .Where(auf => auf.UsersFood.Any(uf => uf.TrainingGuyId.ToString() == userId))
                .Select(auf => new FoodViewModel()
                {
                    Id = auf.Id,
                    Name = auf.Name,
                    Calories = auf.Calories,
                    Carbs = auf.Carbs,
                    Fat = auf.Fat,
                    Protein = auf.Protein,
                    Grams = auf.Grams
                })
                .ToListAsync();
            
            return foods;
        }
        public async Task<ApplicationUserFood?> GetApplicationUserFoodAsync(int foodId, string? userId)
        {
           ApplicationUserFood? userFood = await dbContext
                            .ApplicationUsersFoods
                            .FirstOrDefaultAsync(uf => uf.TrainingGuyId.ToString() == userId && uf.FoodId == foodId);

            return userFood;
        }

        public async Task<ApplicationUserFood?> GetUserFromApplicationUserFoodByUserIdAsync(string? userId)
        {
            ApplicationUserFood user = await dbContext.
                    ApplicationUsersFoods.
                    FirstAsync(auf => auf.TrainingGuyId.ToString() == userId);
            return user;
        }

        public async Task AddingMacrosToAnExistingFoodAsync(UserFood? food, Food? foodWithDefaultValues, double weightMultiplier, int weightGrams)
        {
            food!.Calories += (int)(foodWithDefaultValues!.Calories * weightMultiplier);
            food.Carbs += foodWithDefaultValues.Carbs * weightMultiplier;
            food.Fat += foodWithDefaultValues.Fat * weightMultiplier;
            food.Protein += foodWithDefaultValues.Protein * weightMultiplier;
            food.Grams += weightGrams;

            await dbContext.SaveChangesAsync();
        }

        public async Task AddingNewFoodToListAsync(UserFood? food, Food? foodWithDefaultValues, double weightMultiplier, int weightGrams, int foodId, Guid userGuidId)
        {
            food!.Calories = (int)(foodWithDefaultValues!.Calories * weightMultiplier);
            food.Carbs = foodWithDefaultValues.Carbs * weightMultiplier;
            food.Fat = foodWithDefaultValues.Fat * weightMultiplier;
            food.Protein = foodWithDefaultValues.Protein * weightMultiplier;
            food.Grams = weightGrams;


            food.UsersFood.Add(new ApplicationUserFood()
            {
                FoodId = foodId,
                TrainingGuyId = userGuidId
            });

            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveFoodFromListAsync(ApplicationUserFood? food)
        {
            if (food == null)
            { 
                throw new ArgumentException(ThereIsNoFoodWithThisId);
            }
            dbContext.ApplicationUsersFoods.Remove(food!);

            await dbContext.SaveChangesAsync();
        }

        public async Task<Food> CreateFoodWithDefaultValuesAsync(AddFoodViewModel model)
        {
            Food food = new Food()
            {
                Name = model.Name,
                Calories = model.Calories,
                Carbs = model.Carbs,
                Fat = model.Fat,
                Protein = model.Protein
            };
            await dbContext.Foods.AddAsync(food);
            await dbContext.SaveChangesAsync();
            return food;    
        }

        public async Task<UserFood> CreateFoodThatUserCanModifyAsync(AddFoodViewModel model)
        {
            UserFood userFood = new UserFood()
            {
                Name = model.Name,
                Calories = model.Calories,
                Carbs = model.Carbs,
                Fat = model.Fat,
                Protein = model.Protein
            };
            await dbContext.UsersFoods.AddAsync(userFood);
            await dbContext.SaveChangesAsync();
            return userFood;
        }
    }
}
