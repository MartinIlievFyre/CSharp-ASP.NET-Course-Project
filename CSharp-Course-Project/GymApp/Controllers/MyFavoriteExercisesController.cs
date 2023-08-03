using GymApp.Data;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GymApp.Controllers
{
    [Authorize]
    public class MyFavoriteExercisesController : Controller
    {
        private readonly GymAppDbContext dbContext;
        public MyFavoriteExercisesController(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> MyFavoriteExercises()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exercises = await dbContext
               .Exercises
               .Where(e => e.UsersExercises.Any(ue => ue.TrainingGuyId.ToString() == userId))
               .Select(e => new ExerciseViewModel()
               {
                   Id = e.Id,
                   Name = e.Name,
                   ImageUrl = e.ImageUrl,
                   Benefit = e.Benefit,
                   Execution = e.Execution,
                   Category = e.Category.Name
               })
               .ToListAsync();
            var categories = await dbContext.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
            var models = new CategoryListExerciseViewModel();
            models = new CategoryListExerciseViewModel()
            {
                Categories = categories,
                Exercises = exercises
            };
            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> GetExercise(string id)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var exercises = await dbContext
                    .Exercises
                    .Where(e => e.CategoryId == int.Parse(id) && e.UsersExercises.Any(u => u.TrainingGuyId.ToString() == userId))
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

                if (exercises.Count > 0)
                {
                    return View(exercises);
                }
            }
            catch (Exception)
            {
            }

            return RedirectToAction("MyFavoriteExercises", "MyFavoriteExercises");
        }

        [HttpGet]
        public async Task<IActionResult> ExerciseDetails(string id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentExercise = await dbContext
         .Exercises
         .Where(e => e.Id == int.Parse(id) && e.UsersExercises.Any(u => u.TrainingGuyId.ToString() == userId))
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
        public async Task<IActionResult> RemoveFromMyFavorites(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await dbContext.
                ApplicationUsersExercises.
                FirstAsync(u => u.TrainingGuyId.ToString() == userId);

            var exercise = await dbContext
                .ApplicationUsersExercises
                .FirstOrDefaultAsync(ue => ue.ExerciseId == id && ue.TrainingGuyId.ToString() == userId);

            try
            {
                if (user != null)
                    dbContext.ApplicationUsersExercises.Remove(exercise!);


                await dbContext.SaveChangesAsync();
            }
            catch
            {
                BadRequest();
            }
            return RedirectToAction("MyFavoriteExercises", "MyFavoriteExercises");
        }
    }
}
