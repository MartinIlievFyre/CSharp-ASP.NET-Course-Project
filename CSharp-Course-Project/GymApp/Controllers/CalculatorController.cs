namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;
    using GymApp.Infrastructure.Extensions;

    using static GymApp.Common.NotificationMessagesConstants;

    [Authorize]
    public class CalculatorController : Controller
    {
        private readonly IFoodService foodService;

        public CalculatorController(IFoodService foodService)
        {
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
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AllProducts()
        {
            try
            {
                var foods = await foodService.AllFoodsWithDefaultValuesAsync();
                return View(foods);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToList(int id, int? weight)
        {
            try
            {
                weight = (weight.HasValue && weight > 0) ? weight : 100;
                    string? userId = User.GetId();
                    Guid userGuidId;
                    Guid.TryParse(userId, out userGuidId);

                    var foodWithDefaultValues = await foodService.AllFoodsWithDefaultValuesByIdAsync(id);
                    var food = await foodService.AllUserFoodsByIdAsync(id);

                    if (food != null)
                    {
                        var userFood = await foodService.GetApplicationUserFoodAsync(id, userId);

                        int weightGrams = weight.Value;
                        double weightMultiplier = weightGrams / 100.0;

                        if (foodWithDefaultValues != null && food != null && userFood == null)
                        {
                            await foodService.AddingNewFoodToListAsync(food, foodWithDefaultValues, weightMultiplier, weightGrams, id, userGuidId);
                        }
                        else if (foodWithDefaultValues != null && food != null && userFood != null)
                        {
                            await foodService.AddingMacrosToAnExistingFoodAsync(food, foodWithDefaultValues, weightMultiplier, weightGrams);
                        }
                    }

                TempData["Success"] = SuccessfullyAddedFood;

                return RedirectToAction("CalMacro", "Calculator");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFoodList(int id)
        {
            try
            {
                string? userId = User.GetId();

                var user = await foodService.GetUserFromApplicationUserFoodByUserIdAsync(userId);

                var food = await foodService.GetApplicationUserFoodAsync(id, userId);

                if (food != null)
                {
                    await foodService.RemoveFoodFromListAsync(food);
                }

                TempData["Error"] = SuccessfullyRemovedFood;
                return RedirectToAction("CalMacro", "Calculator");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
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
                Food food = await foodService.CreateFoodWithDefaultValuesAsync(model);
                UserFood userFood = await foodService.CreateFoodThatUserCanModifyAsync(model);
                TempData["Success"] = SuccessfullyCreatedFood;
                return RedirectToAction("CalMacro", "Calculator");

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
