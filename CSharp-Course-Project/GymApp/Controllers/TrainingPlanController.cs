﻿namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.NotificationMessagesConstants;
    using static GymApp.Common.EntityValidationConstants.RolesConstants;
    using GymApp.Infrastructure.Extensions;
    using GymApp.Services.Data;

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

        [HttpGet]
        [Authorize(Roles = NameOfRoleAdmin)]
        public async Task<IActionResult> EditTrainingPlan(int id)
        {
            try
            {
                IEnumerable<CategoryViewModel> categories = await categoryService.AllCategoriesAsync();

                TrainingPlan trainingPlan = await trainingPlanService.GetTrainingPlanByIdAsync(id);

                EditTrainingPlanViewModel model = trainingPlanService.CreateEditTrainingPlanViewModel(trainingPlan, categories);

                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        [Authorize(Roles = NameOfRoleAdmin)]
        public async Task<IActionResult> EditTrainingPlan(EditTrainingPlanViewModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                IEnumerable<CategoryViewModel> categories = await categoryService.AllCategoriesAsync();

                TrainingPlan trainingPlan = await trainingPlanService.GetTrainingPlanByIdAsync(model.Id);


                await trainingPlanService.EditingInformationAboutTrainingPlanAsync(trainingPlan, model);

                TempData["Success"] = SuccessfullyEditTrainingPlan;

                return RedirectToAction("GetTrainingPlan", new { id = model.CategoryId });
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [Authorize(Roles = NameOfRoleAdmin)]
        public async Task<IActionResult> DeleteTrainingPlan(int id)
        {
            try
            {
                TrainingPlan trainingPlan = await trainingPlanService.GetTrainingPlanByIdAsync(id);

                await trainingPlanService.DeleteTrainingPlanAsync(trainingPlan);

                TempData["Error"] = SuccessfullyDeletedTrainingPlan;
                return RedirectToAction("TrainingPlans", "TrainingPlan");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("TrainingPlans", "TrainingPlan");

            }
        }
    }
}
