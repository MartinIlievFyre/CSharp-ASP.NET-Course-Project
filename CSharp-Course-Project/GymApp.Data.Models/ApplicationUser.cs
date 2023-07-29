using System.ComponentModel.DataAnnotations;
using static GymApp.Common.EntityValidationConstants.ApplicationUser;
using Microsoft.AspNetCore.Identity;

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
            IsModerator = false;
            IsDeleted = false;
            CreatedOn = DateTime.UtcNow;
            Orders = new List<Order>();
        }

        [MaxLength(NameMaxLength)]
        public string? Name { get; set; }

        public bool IsModerator { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<ApplicationUserExercise> UsersExercises { get; set; } 
        public ICollection<ApplicationUserFood> UsersFoods { get; set; }
        public ICollection<ApplicationUserTrainingPlan> UsersTrainingPlans { get; set; }

    }
}
