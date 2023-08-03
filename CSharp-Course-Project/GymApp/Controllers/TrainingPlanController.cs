using GymApp.Data;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static GymApp.Common.EntityValidationConstants;

namespace GymApp.Controllers
{
    [Authorize]
    public class TrainingPlanController : Controller
    {
        private readonly GymAppDbContext dbContext;
        public TrainingPlanController(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> TrainingPlans()
        {
            var models = new CategoryListViewModel();
            var categories = await dbContext.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
            models = new CategoryListViewModel()
            {
                Categories = categories
            };
            return View(models);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTrainingPlan(string id)
        {

            var trainingPlans = await dbContext
                .TrainingPlans
                .Where(tp => tp.CategoryId == int.Parse(id))
                .Select(tp => new TrainingPlanViewModel()
                {
                    Id = tp.Id,
                    Name = tp.Name,
                    Description = tp.Description,
                    Category = tp.Category.Name
                    
                })
                .ToListAsync();
            return View(trainingPlans);
        }

        // [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditTrainingPlan(int id)
        {
            var categories = await dbContext.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            })
               .ToListAsync();

            var trainingPlan = await dbContext.TrainingPlans.FindAsync(id);


            EditTrainingPlanViewModel model = new EditTrainingPlanViewModel()
            {
                Id = trainingPlan!.Id,
                Name = trainingPlan.Name,
                Description = trainingPlan.Description,
                CategoryId = trainingPlan.CategoryId,
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditTrainingPlan(EditTrainingPlanViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var categories = await dbContext.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            })
               .ToListAsync();

            var trainingPlan = await dbContext.TrainingPlans.FindAsync(model.Id);

            if (trainingPlan != null)
            {
                trainingPlan.Name = model.Name;
                trainingPlan.Description = model.Description;
                trainingPlan.CategoryId = model.CategoryId;

            }

            await dbContext.SaveChangesAsync();
            return RedirectToAction("GetTrainingPlan", new { id = model.CategoryId });
        }
    }
}
