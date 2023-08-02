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
        [HttpGet]
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ExerciseDetails(string id)
        {
            var currentExercise = await dbContext
         .Exercises
         .Where(e => e.Id == int.Parse(id))
         .Select(e => new ExerciseViewModel()
         {
             Id = e.Id,
             Name = e.Name,
             Execution = e.Execution,
             Benefit = e.Benefit,
             Category = e.Category.Name,
             ImageUrl = e.ImageUrl,
         })
         .FirstOrDefaultAsync();

            if (currentExercise == null)
            {
                return NotFound();
            }

            // Get three random accessory IDs (excluding the current product ID)
            var randomExercisesIds = await dbContext.Exercises
                .Where(e => e.Id != int.Parse(id))
                .Select(e => e.Id)
                .OrderBy(x => Guid.NewGuid())
                .Take(3)
                .ToListAsync();

            // Get the details of three random products
            var randomExercises = await dbContext.Exercises
                .Where(e => randomExercisesIds.Contains(e.Id))
                .Select(e => new ExerciseViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Category = e.Category.Name,
                    ImageUrl = e.ImageUrl
                })
                .ToListAsync();

            var viewModel = new ExerciseDetailsViewModel()
            {
                CurrentExercise = currentExercise,
                RandomExercises = randomExercises
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddToMyFavorites(int id)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Guid userGuidId;
                Guid.TryParse(userId, out userGuidId);

                var exercise = await dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == id);

                if (!await dbContext.ApplicationUsersExercises.AnyAsync(ue => ue.ExerciseId == id))
                {
                    if (exercise != null)
                    {
                        if (!exercise.UsersExercises.Any(ue => ue.TrainingGuyId.ToString() == userId))
                        {
                            exercise.UsersExercises.Add(new ApplicationUserExercise()
                            {
                                ExerciseId = id,
                                TrainingGuyId = userGuidId
                            });
                        }
                    }
                    await dbContext.SaveChangesAsync();
                    Task.Delay(3000).Wait();
                }
                Task.Delay(3000).Wait();
            }
            catch
            {
                BadRequest();
            };
            return RedirectToAction("Exercises", "Gym");
        }
        // [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditExercise(int id)
        {
            var categories = await dbContext.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            })
               .ToListAsync();

            var exercise = await dbContext.Exercises.FindAsync(id);


            EditExerciseViewModel model = new EditExerciseViewModel()
            {
                Id = exercise!.Id,
                Name = exercise.Name,
                Benefit = exercise.Benefit,
                Execution = exercise.Execution,
                ImageUrl = exercise.ImageUrl,
                CategoryId = exercise.CategoryId,
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditExercise(EditExerciseViewModel model)
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

            var exercise = await dbContext.Exercises.FindAsync(model.Id);

            if (exercise != null)
            {
                exercise.Name = model.Name;
                exercise.Benefit = model.Benefit;
                exercise.Execution = model.Execution;
                exercise.ImageUrl = model.ImageUrl;
                exercise.CategoryId = model.CategoryId;
            }

            await dbContext.SaveChangesAsync();
            return RedirectToAction("ExerciseDetails", new { id = model.Id });
        }
    }
}
