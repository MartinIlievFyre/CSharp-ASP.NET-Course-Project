using GymApp.Data.Models;
using GymApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Services.Data.Interfaces
{
    public interface IExerciseService
    {
        AddExerciseViewModel CreateAddExerciseViewModel(List<CategoryViewModel> categories);
        Task<Exercise> CreateExerciseAsync(AddExerciseViewModel model);
    }
}
