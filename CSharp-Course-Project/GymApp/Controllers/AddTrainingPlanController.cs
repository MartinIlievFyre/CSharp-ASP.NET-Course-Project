using GymApp.Data;
using GymApp.Data.Models;
using GymApp.Services.Data;
using GymApp.Services.Data.Interfaces;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Controllers
{
    public class AddTrainingPlanController : Controller
    {
        private readonly GymAppDbContext dbContext;
        private readonly ICategoryService categoryService;
        public AddTrainingPlanController(GymAppDbContext dbContext, ICategoryService categoryService)
        {
            this.dbContext = dbContext;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> AddTrainingPlan()
        {
            try
            {
                List<CategoryViewModel> categories = (List<CategoryViewModel>)await categoryService.AllCategoriesAsync();

                AddTrainingPlanViewModel model = new AddTrainingPlanViewModel()
                {
                    Categories = categories
                };

                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                //To Do
                return NotFound();
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
                //TO DO IF there is a trainingPlan with same name to send alert for that and do nothing
                TrainingPlan trainingPlan = new TrainingPlan()
                 {
                     Name = model.Name,
                     Description = model.Description,
                     CategoryId = model.CategoryId
                 };
                 await dbContext.AddAsync(trainingPlan);
                 await dbContext.SaveChangesAsync();

                 return RedirectToAction("TrainingPlans", "TrainingPlan");

            }
            catch (Exception)
            {
                 return BadRequest();
            }
        }
    }
}
