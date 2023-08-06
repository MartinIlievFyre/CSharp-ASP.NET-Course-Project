namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GymApp.ViewModels;
    using GymApp.Services.Data.Interfaces;
    using GymApp.Infrastructure.Extensions;
    using GymApp.Data.Models;

    using static GymApp.Common.NotificationMessagesConstants;

    [Authorize]
    public class MyFavoriteExercisesController : Controller
    {
        private readonly IExerciseService exerciseService;
        private readonly ICategoryService categoryService;

        public MyFavoriteExercisesController(IExerciseService exerciseService, ICategoryService categoryService)
        {
            this.exerciseService = exerciseService;
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> MyFavoriteExercises()
        {
            try
            {
                string? userId = User.GetId();
                List<ExerciseViewModel> exercises = await exerciseService.GetAllExerciseViewModelsByUserId(userId);
                IEnumerable<CategoryViewModel> categories = await categoryService.AllCategoriesAsync();
                CategoryListExerciseViewModel models = categoryService.CreateCategoryListExerciseViewModel(categories, exercises);
                return View(models);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetExercise(string id)
        {
            try
            {
                string? userId = User.GetId();
                List<ExerciseViewModel> exercises = await exerciseService
                    .GetAllExerciseViewModelsByUserIdAndACategoryId(id, userId);


                return View(exercises);

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("MyFavoriteExercises", "MyFavoriteExercises");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ExerciseDetails(string id)
        {
            try
            {
                string? userId = User.GetId();

                ExerciseViewModel? currentExercise = await exerciseService.GetExerciseViewModelByIdAndUserIdAsync(id, userId);


                // Get three random accessory IDs (excluding the current product ID)
                List<int> randomExercisesIds = await exerciseService.RandomExerciseIdsAsync(id);

                // Get the details of three random products
                List<ExerciseViewModel> randomExercises = await exerciseService.RandomExercisesWithIdsAsync(randomExercisesIds);

                ExerciseDetailsViewModel viewModel = exerciseService.CreateExerciseDetailsViewModel(currentExercise!, randomExercises);

                return View(viewModel);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromMyFavorites(int id)
        {
            try
            {
                string? userId = User.GetId();

                ApplicationUserExercise user = await exerciseService.GetUserFromApplicationUserExerciseAsync(userId);

                ApplicationUserExercise? exercise = await exerciseService.GetExerciseByIdAndUserIdFromApplicationUserExerciseAsync(id, userId);

                await exerciseService.RemoveExerciseFromMyFavoritesAsync(exercise);

                TempData["Error"] = SuccessfullyRemovedeExerciseFormFavorites;
                return RedirectToAction("MyFavoriteExercises", "MyFavoriteExercises");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
