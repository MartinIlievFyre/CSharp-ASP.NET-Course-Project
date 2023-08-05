namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;
    using GymApp.ViewModels;

    using static GymApp.Common.NotificationMessagesConstants;

    public class AddTrainingPlanController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ITrainingPlanService trainingPlanService;
        public AddTrainingPlanController(ITrainingPlanService trainingPlanService, ICategoryService categoryService)
        {
            this.trainingPlanService = trainingPlanService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> AddTrainingPlan()
        {
            try
            {
                List<CategoryViewModel> categories = (List<CategoryViewModel>)await categoryService.AllCategoriesAsync();

                AddTrainingPlanViewModel model = trainingPlanService.CreateAddTrainingPlanViewModel(categories);

                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddTrainingPlan(AddTrainingPlanViewModel model)
        {
            try
            {
                 if (!ModelState.IsValid)
                 {
                     return View(model);
                 }

                TrainingPlan trainingPlan = await trainingPlanService.CreateTrainingPlanAsync(model);

                TempData["Success"] = SuccessfullyCreatedTrainingPlan;
                return RedirectToAction("TrainingPlans", "TrainingPlan");

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("AddTrainingPlan", "AddTrainingPlan");
            }
        }
    }
}
