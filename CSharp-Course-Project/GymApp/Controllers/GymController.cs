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
        public IActionResult AllExercises()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Legs()
        {
            var exercises = await dbContext
                .Exercises
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
        public async Task<IActionResult> Back()
        {
            var exercises = await dbContext
                .Exercises
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
        public async Task<IActionResult> Chest()
        {
            var exercises = await dbContext
                .Exercises
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
        public async Task<IActionResult> Triceps()
        {
            var exercises = await dbContext
                .Exercises
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
        public async Task<IActionResult> Biceps()
        {
            var exercises = await dbContext
                .Exercises
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
        public async Task<IActionResult> Forearms()
        {
            var exercises = await dbContext
                .Exercises
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
        public async Task<IActionResult> Shoulders()
        {
            var exercises = await dbContext
                .Exercises
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
        public async Task<IActionResult> Abs()
        {
            var exercises = await dbContext
                .Exercises
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
       //public async Task<IActionResult> MyFavoriteExercises()
       //{
       //    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
       //    var exercises = await dbContext
       //        .Exercises
       //        .Where(e => e.UsersExercises.Any(ue => ue.TrainingGuyId == userId))
       //        .Select(e => new ExerciseViewModel()
       //        {
       //            Id = e.Id,
       //            Name = e.Name,
       //            ImageUrl = e.ImageUrl,
       //            Benefit = e.Benefit,
       //            Execution = e.Execution,
       //            Category = e.Category.Name
       //        })
       //        .ToListAsync();
       //    return View(exercises);
       //}
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
