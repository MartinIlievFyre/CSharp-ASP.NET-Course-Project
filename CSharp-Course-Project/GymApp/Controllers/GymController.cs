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
    public class GymController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IExerciseService exerciseService;
        public GymController(ICategoryService categoryService, IExerciseService exerciseService)
        {
            this.categoryService = categoryService;
            this.exerciseService = exerciseService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Exercises()
        {
            try
            {
                IEnumerable<CategoryViewModel> categories = await categoryService.AllCategoriesAsync();

                CategoryListViewModel models =
                    categoryService.CreateCategoryListViewModel((ICollection<CategoryViewModel>)categories);
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
        public async Task<IActionResult> GetExercise(string id)
        {
            try
            {
                List<ExerciseViewModel> exercises = await exerciseService.GetAllExerciseViewModelsByCategoryIdAsync(id);
                return View(exercises);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ExerciseDetails(string id)
        {
            try
            {
                ExerciseViewModel? currentExercise = await exerciseService.GetExerciseViewModelByIdAsync(id);

                List<int> randomExercisesIds = await exerciseService.RandomExerciseIdsAsync(id);

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
        public async Task<IActionResult> AddToMyFavorites(int id)
        {
            try
            {
                string? userId = User.GetId();
                Guid userGuidId;
                Guid.TryParse(userId, out userGuidId);

                Exercise? exercise = await exerciseService.GetExerciseByIdAsync(id);

                if (!await exerciseService.IsExerciseWithThisIdExistInApplicationUserExerciseAsync(id))
                {
                    if (!exerciseService.IsThereExerciseWithThisUserInApplicationUserExercises(exercise!, userId))
                    {
                        await exerciseService.CreateNewApplicationUserExerciseAsync(exercise!, id, userGuidId);
                    }
                }

                TempData["Success"] = SuccessfullyAddedExerciseTofavorites;

                return RedirectToAction("Exercises", "Gym");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            };
        }
 
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditExercise(int id)
        {
            try
            {
                IEnumerable<CategoryViewModel> categories = await categoryService.AllCategoriesAsync();

                Exercise? exercise = await exerciseService.GetExerciseByIdAsync(id);

                EditExerciseViewModel model = exerciseService.CreateEditExerciseViewModel(exercise, categories);

                return View(model);

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditExercise(EditExerciseViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                IEnumerable<CategoryViewModel> categories = await categoryService.AllCategoriesAsync();

                Exercise? exercise = await exerciseService.GetExerciseByIdAsync(model.Id);

                await exerciseService.EditingInformationAboutExerciseAsync(exercise!, model);

                TempData["Success"] = SuccessfullyEditExercise;

                return RedirectToAction("ExerciseDetails", new { id = model.Id });
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
