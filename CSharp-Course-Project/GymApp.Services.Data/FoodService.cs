namespace GymApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using GymApp.Data;
    using GymApp.ViewModels;
    using GymApp.Services.Data.Interfaces;
    using static GymApp.Common.ExeptionMessages;
    using GymApp.Data.Models;

    public class FoodService : IFoodService
    {
        private readonly GymAppDbContext dbContext;
        public FoodService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Food> AllFoodsWithDefaultValuesByIdAsync(int foodId)
        {
            var food = await dbContext.Foods.FirstOrDefaultAsync(f => f.Id == foodId);
            if (food == null)
            {
                throw new ArgumentException(ThereIsNoFoodWithThisId);
            }
            return food;
        }

        public async Task<UserFood> AllUserFoodsByIdAsync(int foodId)
        {
            var food = await dbContext.UsersFoods.FirstOrDefaultAsync(f => f.Id == foodId);
            if (food == null)
            {
                throw new ArgumentException(ThereAreNoFoods);
            }
            return food;
        }

        public async Task<IEnumerable<FoodViewModel>> AllFoodsWithDefaultValuesAsync()
        {
            var foods = await this.dbContext
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
            if (foods == null)
            {
                throw new ArgumentException(ThereAreNoFoods);
            }
            return foods;
        }

        public async Task<IEnumerable<FoodViewModel>> AllUserFoodsByUserIdAsync(string? userId)
        {
            var foods =
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
            if (foods == null)
            {
                throw new ArgumentException(ThereAreNoFoods);
            }
            return foods;
        }

    }
}
