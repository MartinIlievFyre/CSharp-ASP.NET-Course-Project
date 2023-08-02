namespace GymApp.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using GymApp.Data;
    using GymApp.Models;
    using System.Security.Claims;
    using GymApp.Data.Models;
    using NuGet.Packaging.Core;

    [Authorize]
    public class CalculatorController : Controller
    {
        private readonly GymAppDbContext dbContext;

        public CalculatorController(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> CalMacro()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var foods = await this.dbContext
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
            return View(foods);
        }
        public async Task<IActionResult> AllProducts()
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
            return View(foods);
        }
        [HttpPost]
        public async Task<IActionResult> AddProductToList(int id, int? weight)
        {
            try
            {
                if (weight.HasValue && weight > 0)
                {
                    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Guid userGuidId;
                    Guid.TryParse(userId, out userGuidId);

                    var foodWithDefaultValues = await dbContext.Foods.FirstOrDefaultAsync(f => f.Id == id);
                    var food = await dbContext.UsersFoods.FirstOrDefaultAsync(f => f.Id == id);
                    if (food != null)
                    {
                        //var userFood = food
                        //    .UsersFood
                        //    .FirstOrDefault(uf => uf.TrainingGuyId == userGuidId && uf.FoodId == id);
                        var userFood = await dbContext
                            .ApplicationUsersFoods
                            .FirstOrDefaultAsync(uf => uf.TrainingGuyId == userGuidId && uf.FoodId == id);

                        int weightGrams = weight.Value;
                        double weightMultiplier = weightGrams / 100.0;

                        if (foodWithDefaultValues != null && food != null && userFood == null)
                        {

                            food.Calories = (int)(foodWithDefaultValues.Calories * weightMultiplier);
                            food.Carbs = foodWithDefaultValues.Carbs * weightMultiplier;
                            food.Fat = foodWithDefaultValues.Fat * weightMultiplier;
                            food.Protein = foodWithDefaultValues.Protein * weightMultiplier;
                            food.Grams = weightGrams;


                            food.UsersFood.Add(new ApplicationUserFood()
                            {
                                FoodId = id,
                                TrainingGuyId = userGuidId
                            });

                            await dbContext.SaveChangesAsync();
                        }
                        else if (foodWithDefaultValues != null && food != null && userFood != null)
                        {
                            food.Calories += (int)(foodWithDefaultValues.Calories * weightMultiplier);
                            food.Carbs += foodWithDefaultValues.Carbs * weightMultiplier;
                            food.Fat += foodWithDefaultValues.Fat * weightMultiplier;
                            food.Protein += foodWithDefaultValues.Protein * weightMultiplier;
                            food.Grams += weightGrams;
                            await dbContext.SaveChangesAsync();
                        }
                    }
                }
                else
                {
                    return RedirectToAction("AllProducts", "Calculator");
                }
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction("AllProducts", "Calculator");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromFoodList(int id)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var user = await dbContext.
                    ApplicationUsersFoods.
                    FirstAsync(auf => auf.TrainingGuyId.ToString() == userId);

                var food = await dbContext
                    .ApplicationUsersFoods
                    .Where(auf => auf.TrainingGuyId.ToString() == userId)
                    .FirstAsync(auf => auf.FoodId == id);

                if (food != null)
                {

                    dbContext.ApplicationUsersFoods.Remove(food!);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch
            {
                BadRequest();
            }
            return RedirectToAction("CalMacro", "Calculator");
        }
        [HttpGet]
        public IActionResult AddFood()
        {
            AddFoodViewModel model = new AddFoodViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddFood(AddFoodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Food food = new Food()
            {
                Name = model.Name, 
                Calories = model.Calories,
                Carbs = model.Carbs,
                Fat = model.Fat,
                Protein = model.Protein
            };
            UserFood userFood = new UserFood()
            {
                Name = model.Name,
                Calories = model.Calories,
                Carbs = model.Carbs,
                Fat = model.Fat,
                Protein = model.Protein
            };
            await dbContext.Foods.AddAsync(food);
            await dbContext.UsersFoods.AddAsync(userFood);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("CalMacro", "Calculator");
        }
    }
}
