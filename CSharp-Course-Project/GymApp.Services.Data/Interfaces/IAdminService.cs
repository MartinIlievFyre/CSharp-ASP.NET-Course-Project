using GymApp.Data.Models;
using GymApp.ViewModels;
using GymApp.ViewModels.Accessory;
using GymApp.ViewModels.Clothing;
using GymApp.ViewModels.Supplement;
using GymApp.ViewModels.WearCategory;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Services.Data.Interfaces
{
    public interface IAdminService
    {
        //ACCESSORY
        Task DeleteAccessoryAsync(Accessory accessory);
        Task<Accessory> GetAccessoryByIdAsync(int accessoryId);
        Task<Accessory> CreateAccessoryAsync(AddAccessoryViewModel model);
        AddAccessoryViewModel CreateAddAccessoryViewModel();
        EditAccessoryViewModel CreateEditAccessoryViewModel(Accessory accessory);
        Task EditingInformationAboutAccessoryAsync(Accessory accessory, EditAccessoryViewModel model);

        //SUPPLEMENT
        Task DeleteSupplementAsync(Supplement supplement);
        Task<Supplement> GetSupplementByIdAsync(int supplementId);
        Task<Supplement> CreateSupplementAsync(AddSupplementViewModel model);
        AddSupplementViewModel CreateAddSupplementViewModel();
        EditSupplementViewModel CreateEditSupplementViewModel(Supplement supplement);
        Task EditingInformationAboutSupplementAsync(Supplement supplement, EditSupplementViewModel model);

        //WEAR
        Task DeleteWearAsync(Wear wear);
        Task<Wear> GetWearByIdAsync(int wearId);
        Task<Wear> CreateWearAsync(AddWearViewModel model);
        AddWearViewModel CreateAddWearViewModel(List<WearCategoryViewModel> categories);
        EditWearViewModel CreateEditWearViewModel(Wear? wear, IEnumerable<WearCategoryViewModel> categories);
        Task EditingInformationAboutWearAsync(Wear wear, EditWearViewModel model);

        //EXERCISE
        Task DeleteExerciseAsync(Exercise exercise);
        Task<Exercise> CreateExerciseAsync(AddExerciseViewModel model);
        Task<Exercise?> GetExerciseByIdAsync(int exerciseId);
        AddExerciseViewModel CreateAddExerciseViewModel(List<CategoryViewModel> categories);
        EditExerciseViewModel CreateEditExerciseViewModel(Exercise? exercise, IEnumerable<CategoryViewModel> categories);
        Task EditingInformationAboutExerciseAsync(Exercise exercise, EditExerciseViewModel model);
        //TRAINING PLAN
        Task DeleteTrainingPlanAsync(TrainingPlan trainingPlan);
        Task<TrainingPlan> GetTrainingPlanByIdAsync(int trainingPlanId);
        Task<TrainingPlan> CreateTrainingPlanAsync(AddTrainingPlanViewModel model);
        AddTrainingPlanViewModel CreateAddTrainingPlanViewModel(List<CategoryViewModel> categories);
        EditTrainingPlanViewModel CreateEditTrainingPlanViewModel(TrainingPlan? trainingPlan, IEnumerable<CategoryViewModel> categories);
        Task EditingInformationAboutTrainingPlanAsync(TrainingPlan trainingPlan, EditTrainingPlanViewModel model);

        //PANEL
        Task<List<ApplicationUser>> UsersListAsync();
        Task<List<ApplicationUser>> UserInListByUsernameAsync(string searchInput);
        Task<ApplicationUser> GetApplicationUserByIdAsync(string userId);
        Task SoftDeletingUser(ApplicationUser user);
        Task PromoteUserToAdmin(string username);
        Task DemoteAdminAsync(string username);
    }
}
