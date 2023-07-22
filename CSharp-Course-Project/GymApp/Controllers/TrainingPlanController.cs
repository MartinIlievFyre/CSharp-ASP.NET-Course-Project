using GymApp.Data;
using GymApp.Data.Models;
using GymApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
    }
}
