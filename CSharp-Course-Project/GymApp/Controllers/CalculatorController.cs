namespace GymApp.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using GymApp.Data;
    using System.Security.Claims;
    using GymApp.Data.Models;
    using GymApp.ViewModels;
    using GymApp.Infrastructure.Extensions;
    using GymApp.Services.Data.Interfaces;

    [Authorize]
    public class CalculatorController : Controller
    {
        private readonly GymAppDbContext dbContext;
        private readonly IFoodService foodService;

        public CalculatorController(GymAppDbContext dbContext, IFoodService foodService)
        {
            this.dbContext = dbContext;
            this.foodService = foodService;
        }
        [HttpGet]
        public async Task<IActionResult> CalMacro()
        {
            try
            {
                string? userId = User.GetId();
                var foods = await foodService.AllUserFoodsByUserIdAsync(userId);
                
                return View(foods);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return NotFound();
            }
        }
        public async Task<IActionResult> AllProducts()
        {
            try
            {
                var foods = await foodService.AllFoodsWithDefaultValuesAsync();
                return View(foods);
            }
            catch (ArgumentException ex)
            {   
                //To DO
                TempData["Error"] = ex.Message;
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddProductToList(int id, int? weight)
        {
            try
            {
                if (weight.HasValue && weight > 0)
                {
                    string? userId = User.GetId();
                    Guid userGuidId;
                    Guid.TryParse(userId, out userGuidId);

                    var foodWithDefaultValues = await foodService.AllFoodsWithDefaultValuesByIdAsync(id);
                    var food = await foodService.AllUserFoodsByIdAsync(id);

                    if (food != null)
                    {
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
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
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
            try
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
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}
