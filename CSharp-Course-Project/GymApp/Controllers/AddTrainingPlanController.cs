using GymApp.Data;
using GymApp.Data.Models;
using GymApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Controllers
{
    public class AddTrainingPlanController : Controller
    {
        private readonly GymAppDbContext dbContext;
        public AddTrainingPlanController(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> AddTrainingPlan()
        {
            var categories = await dbContext.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
                .ToListAsync();
            AddTrainingPlanViewModel model = new AddTrainingPlanViewModel()
            {
                Categories = categories
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddTrainingPlan(AddTrainingPlanViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
    }
}
