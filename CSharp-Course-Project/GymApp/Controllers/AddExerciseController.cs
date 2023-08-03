using GymApp.Data;
using GymApp.Data.Models;
using GymApp.Services.Data.Interfaces;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Controllers
{
    [Authorize]
    public class AddExerciseController : Controller
    {
        private readonly GymAppDbContext dbContext;
        private readonly ICategoryService categoryService;
        public AddExerciseController(GymAppDbContext dbContext, ICategoryService categoryService)
        {
            this.dbContext = dbContext;
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> AddExercise()
        {
            try
            {
                List<CategoryViewModel> categories = (List<CategoryViewModel>)await categoryService.AllCategoriesAsync(); 
                    
                AddExerciseViewModel model = new AddExerciseViewModel()
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
        public async Task<IActionResult> AddExercise(AddExerciseViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                
                //TO DO IF there is a exercise with same name to send alert for that and do nothing

                Exercise exercise = new Exercise()
                {
                    Name = model.Name,
                    Execution = model.Execution,
                    Benefit = model.Benefit,
                    ImageUrl = model.ImageUrl,
                    CategoryId = model.CategoryId
                };
                await dbContext.AddAsync(exercise);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("Exercises", "Gym");

            }
            catch (Exception)
            {
                //TO Do
                return BadRequest();
            }
        }
    }
}
