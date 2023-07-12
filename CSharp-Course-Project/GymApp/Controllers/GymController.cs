namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using GymApp.Data;

    using GymApp.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;
    using System.Security.Claims;
    using GymApp.Data.Models;

    [Authorize]
    public class GymController : Controller
    {
        private readonly GymAppDbContext dbContext;
        public GymController(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [AllowAnonymous]
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Exercises()
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
        public async Task<IActionResult> GetExercise(string id)
        {

            var exercises = await dbContext
                .Exercises
                .Where(e => e.CategoryId == int.Parse(id))
                .Select(e => new ExerciseViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Execution = e.Execution,
                    Benefit = e.Benefit,
                    Category = e.Category.Name,
                    ImageUrl = e.ImageUrl
                })
                .ToListAsync();

            return View(exercises);
        }
        [HttpPost]
        public async Task<IActionResult> AddToMyFavorites(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var exercise = await dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == id);
            try
            {
                if (!exercise.UsersExercises.Any(ue => ue.TrainingGuyId == userId))
                {
                    exercise.UsersExercises.Add(new IdentityUserExercise()
                    {
                        ExerciseId = id,
                        TrainingGuyId = userId
                    });
                }

                await dbContext.SaveChangesAsync();
            }
            catch
            {
                BadRequest();
            }
            return RedirectToAction($"Exercises", "Gym");
        }
        

        [HttpGet]
        public async Task<IActionResult> AddExercise()
        {
            var categories = await dbContext.Categories.Select(e => new CategoryViewModel()
            {
                Id = e.Id,
                Name = e.Name
            })
                .ToListAsync();
            AddExerciseViewModel model = new AddExerciseViewModel()
            {
                Categories = categories
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddExercise(AddExerciseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
    }
}
