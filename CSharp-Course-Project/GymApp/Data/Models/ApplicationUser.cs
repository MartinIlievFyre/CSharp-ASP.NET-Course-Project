using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static GymApp.Common.EntityValidationConstants.ApplicationUser;

namespace GymApp.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            UsersExercises = new List<ApplicationUserExercise>();
            UsersFoods = new List<ApplicationUserFood>();
            UsersTrainingPlans = new List<ApplicationUserTrainingPlan>();
        }

        [MaxLength(NameMaxLength)]
        public string? Name { get; set; }
        public int Age { get; set; }

        [MaxLength(BioMaxLength)]
        public string? Bio { get; set; }

        [MaxLength(CityNameMaxLength)]
        public string? CityName { get; set; }
        public ICollection<ApplicationUserExercise> UsersExercises { get; set; } 
        public ICollection<ApplicationUserFood> UsersFoods { get; set; }
        public ICollection<ApplicationUserTrainingPlan> UsersTrainingPlans { get; set; }

    }
}
