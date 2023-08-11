namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GymApp.ViewModels;
    using GymApp.Services.Data.Interfaces;

    [Authorize]
    public class TrainingPlanController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ITrainingPlanService trainingPlanService;
        public TrainingPlanController(ICategoryService categoryService, ITrainingPlanService trainingPlanService)
        {
            this.categoryService = categoryService;
            this.trainingPlanService = trainingPlanService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> TrainingPlans()
        {
            try
            {
                IEnumerable<CategoryViewModel> categories = await categoryService.AllCategoriesAsync();
                CategoryListViewModel models = categoryService.CreateCategoryListViewModel((ICollection<CategoryViewModel>)categories);
                return View(models);

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTrainingPlan(string id)
        {
            try
            {
                var trainingPlans = await trainingPlanService.GetAllTrainingPlanByCategoryId(id);

                return View(trainingPlans);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
