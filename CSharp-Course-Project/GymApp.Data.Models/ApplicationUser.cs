namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
    
    using static GymApp.Common.EntityValidationConstants.ApplicationUser;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            UsersExercises = new List<ApplicationUserExercise>();
            UsersFoods = new List<ApplicationUserFood>();
            UsersTrainingPlans = new List<ApplicationUserTrainingPlan>();
            Products = new List<Product>();
            IsModerator = false;
            IsDeleted = false;
            CreatedOn = DateTime.UtcNow;
        }

        [MaxLength(NameMaxLength)]
        public string? Name { get; set; }

        public bool IsModerator { get; set; }

        public bool IsDeleted { get; set; }

        public byte[]? ProfilePicture { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<ApplicationUserExercise> UsersExercises { get; set; } 
        public ICollection<ApplicationUserFood> UsersFoods { get; set; }
        public ICollection<ApplicationUserTrainingPlan> UsersTrainingPlans { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
