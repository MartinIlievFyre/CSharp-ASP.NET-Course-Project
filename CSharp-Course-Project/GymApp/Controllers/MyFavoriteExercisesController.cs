using GymApp.Data;
using GymApp.Models;
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
        public IActionResult MyFavoriteExercises()
        {
            return View();
        }
        public async Task<IActionResult> LegsExercises()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exercises = await dbContext
                .Exercises
                .Where(e => e.UsersExercises.Any(ue => ue.TrainingGuyId == userId))
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
            return View(exercises);
        }
        public async Task<IActionResult> BicepsExercises()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exercises = await dbContext
                .Exercises
                .Where(e => e.UsersExercises.Any(ue => ue.TrainingGuyId == userId))
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
            return View(exercises);
        }
        public async Task<IActionResult> BackExercises()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exercises = await dbContext
                .Exercises
                .Where(e => e.UsersExercises.Any(ue => ue.TrainingGuyId == userId))
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
            return View(exercises);
        }
        public async Task<IActionResult> TricepsExercises()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exercises = await dbContext
                .Exercises
                .Where(e => e.UsersExercises.Any(ue => ue.TrainingGuyId == userId))
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
            return View(exercises);
        }
        public async Task<IActionResult> ChestExercises()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exercises = await dbContext
                .Exercises
                .Where(e => e.UsersExercises.Any(ue => ue.TrainingGuyId == userId))
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
            return View(exercises);
        }
        public async Task<IActionResult> ForearmsExercises()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exercises = await dbContext
                .Exercises
                .Where(e => e.UsersExercises.Any(ue => ue.TrainingGuyId == userId))
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
            return View(exercises);
        }
        public async Task<IActionResult> AbsExercises()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exercises = await dbContext
                .Exercises
                .Where(e => e.UsersExercises.Any(ue => ue.TrainingGuyId == userId))
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
            return View(exercises);
        }
        public async Task<IActionResult> ShouldersExercises()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var exercises = await dbContext
                .Exercises
                .Where(e => e.UsersExercises.Any(ue => ue.TrainingGuyId == userId))
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
            return View(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromMyFavorites(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await dbContext.
                IdentityUsersExercises.
                FirstAsync(u => u.TrainingGuyId == userId);

            var exercise = await dbContext
                .IdentityUsersExercises
                .FirstOrDefaultAsync(ue => ue.ExerciseId == id && ue.TrainingGuyId == userId);

            try
            {
                if (user != null)
                    dbContext.IdentityUsersExercises.Remove(exercise!);


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
