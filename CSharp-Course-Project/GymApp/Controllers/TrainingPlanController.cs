using GymApp.Data;
using GymApp.Data.Models;
using GymApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult TrainingPlans()
        {
            return View();
        }
        public async Task<IActionResult> TrainingPlansLegs()
        {
            var trainingPlans = await dbContext
                .TrainingPlans
                .Select(tp => new TrainingPlanViewModel()
                {
                    Id = tp.Id,
                    Name = tp.Name,
                     Description = tp.Description,
                    Category = tp.Category.Name,
                })
                .ToListAsync();
        
            return View(trainingPlans);
        }
        public async Task<IActionResult> TrainingPlansBack()
        {
            var trainingPlans = await dbContext
                .TrainingPlans
                .Select(tp => new TrainingPlanViewModel()
                {
                    Id = tp.Id,
                    Name = tp.Name,
                    Description = tp.Description,
                    Category = tp.Category.Name,
                })
                .ToListAsync();

            return View(trainingPlans);
        }
        public async Task<IActionResult> TrainingPlansTriceps()
        {
            var trainingPlans = await dbContext
                .TrainingPlans
                .Select(tp => new TrainingPlanViewModel()
                {
                    Id = tp.Id,
                    Name = tp.Name,
                    Description = tp.Description,
                    Category = tp.Category.Name,
                })
                .ToListAsync();

            return View(trainingPlans);
        }
        public async Task<IActionResult> TrainingPlansBiceps()
        {
            var trainingPlans = await dbContext
                .TrainingPlans
                .Select(tp => new TrainingPlanViewModel()
                {
                    Id = tp.Id,
                    Name = tp.Name,
                    Description = tp.Description,
                    Category = tp.Category.Name,
                })
                .ToListAsync();

            return View(trainingPlans);
        }
        public async Task<IActionResult> TrainingPlansForearms()
        {
            var trainingPlans = await dbContext
                .TrainingPlans
                .Select(tp => new TrainingPlanViewModel()
                {
                    Id = tp.Id,
                    Name = tp.Name,
                    Description = tp.Description,
                    Category = tp.Category.Name,
                })
                .ToListAsync();

            return View(trainingPlans);
        }
        public async Task<IActionResult> TrainingPlansAbs()
        {
            var trainingPlans = await dbContext
                .TrainingPlans
                .Select(tp => new TrainingPlanViewModel()
                {
                    Id = tp.Id,
                    Name = tp.Name,
                    Description = tp.Description,
                    Category = tp.Category.Name,
                })
                .ToListAsync();

            return View(trainingPlans);
        }
        public async Task<IActionResult> TrainingPlansChest()
        {
            var trainingPlans = await dbContext
                .TrainingPlans
                .Select(tp => new TrainingPlanViewModel()
                {
                    Id = tp.Id,
                    Name = tp.Name,
                    Description = tp.Description,
                    Category = tp.Category.Name,
                })
                .ToListAsync();

            return View(trainingPlans);
        }
        public async Task<IActionResult> TrainingPlansShoulders()
        {
            var trainingPlans = await dbContext
                .TrainingPlans
                .Select(tp => new TrainingPlanViewModel()
                {
                    Id = tp.Id,
                    Name = tp.Name,
                    Description = tp.Description,
                    Category = tp.Category.Name,
                })
                .ToListAsync();

            return View(trainingPlans);
        }
        [HttpGet]
        public async Task<IActionResult> AddTrainingPlan()
        {
            var categories = await dbContext.Categories.Select(e => new CategoryViewModel()
            {
                Id = e.Id,
                Name = e.Name
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
