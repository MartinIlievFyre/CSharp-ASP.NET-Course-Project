namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.ViewModels.Clothing;
    using GymApp.ViewModels.Accessory;
    using GymApp.ViewModels.Supplement;
    using GymApp.ViewModels.WearCategory;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.NotificationMessagesConstants;
    using static GymApp.Common.EntityValidationConstants.RolesConstants;
    using GymApp.Services.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    [Authorize(Roles = NameOfRoleAdmin)]
    [AutoValidateAntiforgeryToken]
    public class AdminController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAdminService adminService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ICategoryService categoryService, IAdminService adminService, UserManager<ApplicationUser> userManager)
        {
            this.adminService = adminService;
            this.categoryService = categoryService;
            _userManager = userManager;
        }
        //ADD AND DELETE - ACCESSORY
        [HttpGet]
        public IActionResult AddAccessory()
        {
            try
            {
                AddAccessoryViewModel model = adminService.CreateAddAccessoryViewModel();

                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddAccessory(AddAccessoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                Accessory accessory = await adminService.CreateAccessoryAsync(model);

                TempData["Success"] = SuccessfullyCreatedAccessory;
                return RedirectToAction("Accessories", "Accessory");

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("AddAccessory", "Admin");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccessory(int id)
        {
            try
            {
                Accessory accessory = await adminService.GetAccessoryByIdAsync(id);

                await adminService.DeleteAccessoryAsync(accessory);

                TempData["Error"] = SuccessfullyDeletedAccessory;
                return RedirectToAction("Accessories", "Accessory");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");

            }
        }

        //ADD AND DELETE - SUPPLEMENT
        [HttpGet]
        public IActionResult AddSupplement()
        {
            try
            {
                AddSupplementViewModel model = adminService.CreateAddSupplementViewModel();

                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddSupplement(AddSupplementViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                Supplement supplement = await adminService.CreateSupplementAsync(model);

                TempData["Success"] = SuccessfullyCreatedSupplement;
                return RedirectToAction("Supplements", "Supplement");

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("AddSupplement", "Admin");
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditSupplement(int id)
        {
            try
            {
                Supplement supplement = await adminService.GetSupplementByIdAsync(id);

                EditSupplementViewModel model = adminService.CreateEditSupplementViewModel(supplement);

                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditSupplement(EditSupplementViewModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                Supplement supplement = await adminService.GetSupplementByIdAsync(model.Id);


                await adminService.EditingInformationAboutSupplementAsync(supplement, model);

                TempData["Success"] = SuccessfullyEditSypplement;

                return RedirectToAction("Supplements", "Supplement");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("EditSupplement", "Admin");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSupplement(int id)
        {
            try
            {
                Supplement supplement = await adminService.GetSupplementByIdAsync(id);

                await adminService.DeleteSupplementAsync(supplement);

                TempData["Error"] = SuccessfullyDeletedSupplement;
                return RedirectToAction("Supplements", "Supplement");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");

            }
        }

        //ADD AND DELETE - CLOTHING
        [HttpGet]
        public async Task<IActionResult> AddWear()
        {
            try
            {
                List<WearCategoryViewModel> categories = (List<WearCategoryViewModel>)await categoryService.AllWearCategoriesAsync();

                AddWearViewModel model = adminService.CreateAddWearViewModel(categories);

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


                Wear wear = await adminService.CreateWearAsync(model);
                TempData["Success"] = SuccessfullyCreatedClothing;
                return RedirectToAction("Clothes", "Clothing");

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("AddWear", "Admin");
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditWear(int id)
        {
            try
            {
                IEnumerable<WearCategoryViewModel> categories = await categoryService.AllWearCategoriesAsync();

                Wear wear = await adminService.GetWearByIdAsync(id);

                EditWearViewModel model = adminService.CreateEditWearViewModel(wear, categories);

                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditWear(EditWearViewModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                IEnumerable<WearCategoryViewModel> categories = await categoryService.AllWearCategoriesAsync();

                Wear wear = await adminService.GetWearByIdAsync(model.Id);


                await adminService.EditingInformationAboutWearAsync(wear, model);

                TempData["Success"] = SuccessfullyEditWear;

                return RedirectToAction("GetClothing", "Clothing", new { id = model.CategoryId });
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("EditWear", "Admin");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteWear(int id)
        {
            try
            {
                Wear wear = await adminService.GetWearByIdAsync(id);

                await adminService.DeleteWearAsync(wear!);

                TempData["Error"] = SuccessfullyDeletedWear;
                return RedirectToAction("Clothes", "Clothing");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");

            }
        }

        //ADD AND DELETE - EXERCISE
        [HttpGet]
        public async Task<IActionResult> AddExercise()
        {
            try
            {
                List<CategoryViewModel> categories = (List<CategoryViewModel>)await categoryService.AllCategoriesAsync();

                AddExerciseViewModel model = adminService.CreateAddExerciseViewModel(categories);

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


                Exercise exercise = await adminService.CreateExerciseAsync(model);
                TempData["Success"] = SuccessfullyCreatedExercise;
                return RedirectToAction("Exercises", "Gym");

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("AddExercise", "Admin");
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditExercise(int id)
        {
            try
            {
                IEnumerable<CategoryViewModel> categories = await categoryService.AllCategoriesAsync();

                Exercise? exercise = await adminService.GetExerciseByIdAsync(id);

                EditExerciseViewModel model = adminService.CreateEditExerciseViewModel(exercise, categories);

                return View(model);

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditExercise(EditExerciseViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                IEnumerable<CategoryViewModel> categories = await categoryService.AllCategoriesAsync();

                Exercise? exercise = await adminService.GetExerciseByIdAsync(model.Id);

                await adminService.EditingInformationAboutExerciseAsync(exercise!, model);

                TempData["Success"] = SuccessfullyEditExercise;

                return RedirectToAction("ExerciseDetails", new { id = model.Id });
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("EditExercise", "Admin");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            try
            {
                var exercise = await adminService.GetExerciseByIdAsync(id);

                await adminService.DeleteExerciseAsync(exercise!);

                TempData["Error"] = SuccessfullyDeletedExercise;
                return RedirectToAction("Exercises", "Gym");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        //ADD AND DELETE - TRAINING PLAN
        [HttpGet]
        public async Task<IActionResult> AddTrainingPlan()
        {
            try
            {
                List<CategoryViewModel> categories = (List<CategoryViewModel>)await categoryService.AllCategoriesAsync();

                AddTrainingPlanViewModel model = adminService.CreateAddTrainingPlanViewModel(categories);

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

                TrainingPlan trainingPlan = await adminService.CreateTrainingPlanAsync(model);

                TempData["Success"] = SuccessfullyCreatedTrainingPlan;
                return RedirectToAction("TrainingPlans", "TrainingPlan");

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("AddTrainingPlan", "Admin");
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditTrainingPlan(int id)
        {
            try
            {
                IEnumerable<CategoryViewModel> categories = await categoryService.AllCategoriesAsync();

                TrainingPlan trainingPlan = await adminService.GetTrainingPlanByIdAsync(id);

                EditTrainingPlanViewModel model = adminService.CreateEditTrainingPlanViewModel(trainingPlan, categories);

                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditTrainingPlan(EditTrainingPlanViewModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                IEnumerable<CategoryViewModel> categories = await categoryService.AllCategoriesAsync();

                TrainingPlan trainingPlan = await adminService.GetTrainingPlanByIdAsync(model.Id);


                await adminService.EditingInformationAboutTrainingPlanAsync(trainingPlan, model);

                TempData["Success"] = SuccessfullyEditTrainingPlan;

                return RedirectToAction("GetTrainingPlan", "TrainingPlan", new { id = model.CategoryId });
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("EditTrainingPlan", "Admin");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTrainingPlan(int id)
        {
            try
            {
                TrainingPlan trainingPlan = await adminService.GetTrainingPlanByIdAsync(id);

                await adminService.DeleteTrainingPlanAsync(trainingPlan);

                TempData["Error"] = SuccessfullyDeletedTrainingPlan;
                return RedirectToAction("TrainingPlans", "TrainingPlan");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");

            }
        }

        //ADMIN PANEL
        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            try
            {
                List<ApplicationUser> users = await adminService.UsersListAsync();
                return View(users);

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                ApplicationUser user = await adminService.GetApplicationUserByIdAsync(id.ToString());
                if (user != null && user.IsDeleted == false)
                {
                    await adminService.SoftDeletingUser(user);
                    TempData["Success"] = "Successfully deleted user";
                    return RedirectToAction("UserList");
                }
                else
                {
                    TempData["Error"] = ThisUserIsAlreadyDeleted;
                    return RedirectToAction("UserList", "Admin");
                }
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("UserList", "Admin");
            }
        }
    }
}
