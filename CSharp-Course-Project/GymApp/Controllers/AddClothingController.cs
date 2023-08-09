namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static GymApp.Common.NotificationMessagesConstants;
    using static GymApp.Common.EntityValidationConstants.RolesConstants;
    using GymApp.Services.Data.Interfaces;
    using GymApp.ViewModels;
    using GymApp.ViewModels.Clothing;
    using GymApp.Data.Models;
    using GymApp.ViewModels.WearCategory;

    [Authorize(Roles = NameOfRoleAdmin)]
    public class AddClothingController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IWearService wearService;
        public AddClothingController(ICategoryService categoryService, IWearService wearService)
        {
            this.categoryService = categoryService;
            this.wearService = wearService;
        }
        [HttpGet]
        public async Task<IActionResult> AddWear()
        {
            try
            {
                List<WearCategoryViewModel> categories = (List<WearCategoryViewModel>)await categoryService.AllWearCategoriesAsync();

                AddWearViewModel model = wearService.CreateAddWearViewModel(categories);

                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddWear(AddWearViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }


                Wear wear = await wearService.CreateWearAsync(model);
                TempData["Success"] = SuccessfullyCreatedClothing;
                return RedirectToAction("Exercises", "Gym");

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("AddExercise", "AddExercise");
            }
        }
    }
}
