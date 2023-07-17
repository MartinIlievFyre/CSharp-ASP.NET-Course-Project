namespace GymApp.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using GymApp.Data;
    using GymApp.Models;
    using System.Security.Claims;
    using GymApp.Data.Models;

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
                .Foods
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
                // if (weight.HasValue && weight > 0)
                // {
                //     string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //     Guid userGuidId;
                //     Guid.TryParse(userId, out userGuidId);
                //
                //     var food = await dbContext.Foods.FirstOrDefaultAsync(e => e.Id == id);
                //     var userFood = food.UsersFood.FirstOrDefault(ue => ue.TrainingGuyId == userGuidId);
                //
                //     if (food != null && userFood == null)
                //     {
                //         int weightGrams = weight.Value;
                //         double weightMultiplier = weightGrams / 100.0;
                //
                //         food.Calories *= (int)weightMultiplier;
                //         food.Carbs *= weightMultiplier;
                //         food.Fat *= weightMultiplier;
                //         food.Protein *= weightMultiplier;
                //         food.Grams = weightGrams;
                //
                //         food.UsersFood.Add(new ApplicationUserFood()
                //         {
                //             FoodId = id,
                //             TrainingGuyId = userGuidId
                //         });
                //
                //         await dbContext.SaveChangesAsync();
                //     }
                // }
                if (weight.HasValue && weight > 0)
                {
                    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Guid userGuidId;
                    Guid.TryParse(userId, out userGuidId);

                    var food = await dbContext.Foods.FirstOrDefaultAsync(e => e.Id == id);
                    var userFood = food.UsersFood.FirstOrDefault(ue => ue.TrainingGuyId == userGuidId);

                    if (food != null && userFood == null)
                    {
                        int weightGrams = weight.Value;
                        double weightMultiplier = weightGrams / 100.0;

                        var originalFood = new FoodViewModel
                        {
                            Id = food.Id,
                            Name = food.Name,
                            Calories = food.Calories,
                            Carbs = food.Carbs,
                            Fat = food.Fat,
                            Protein = food.Protein,
                            Grams = food.Grams
                        };

                        food.Calories *= (int)weightMultiplier;
                        food.Carbs *= weightMultiplier;
                        food.Fat *= weightMultiplier;
                        food.Protein *= weightMultiplier;
                        food.Grams = weightGrams;

                        food.UsersFood.Add(new ApplicationUserFood()
                        {
                            FoodId = id,
                            TrainingGuyId = userGuidId
                        });

                        await dbContext.SaveChangesAsync();

                        // Send the modified food values to the view
                        ViewData["ModifiedFood"] = food;

                        // Restore the original food values after sending them
                        food.Calories = originalFood.Calories;
                        food.Carbs = originalFood.Carbs;
                        food.Fat = originalFood.Fat;
                        food.Protein = originalFood.Protein;
                        food.Grams = originalFood.Grams;
                    }
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
        public async Task<IActionResult> AddFood()
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

            FoodViewModel food = new FoodViewModel()
            {
                Name = model.Name,
                Calories = model.Calories,
                Carbs = model.Carbs,
                Fat = model.Fat,
                Protein = model.Protein
            };
            await dbContext.AddAsync(food);
            await dbContext.SaveChangesAsync();
            //To do                  Foods
            return RedirectToAction("CalMacro", "Calculator");
        }
    }
}
