namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;
    
    using static GymApp.Common.NotificationMessagesConstants;

    [Authorize]
    public class AddExerciseController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IExerciseService exerciseService;
        public AddExerciseController( ICategoryService categoryService, IExerciseService exerciseService)
        {
            this.categoryService = categoryService;
            this.exerciseService = exerciseService;
        }
        [HttpGet]
        public async Task<IActionResult> AddExercise()
        {
            try
            {
                List<CategoryViewModel> categories = (List<CategoryViewModel>)await categoryService.AllCategoriesAsync(); 
                    
                AddExerciseViewModel model = exerciseService.CreateAddExerciseViewModel(categories);

                 return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddExercise(AddExerciseViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                
                //TO DO IF there is a exercise with same name to send alert for that and do nothing

                Exercise exercise = await exerciseService.CreateExerciseAsync(model);
                TempData["Success"] = SuccessfullyCreatedExercise;
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
