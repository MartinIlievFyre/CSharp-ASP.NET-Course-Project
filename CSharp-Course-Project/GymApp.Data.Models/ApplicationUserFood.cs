namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUserFood
    {
        [Required]
        public Guid TrainingGuyId { get; set; }
        [ForeignKey(nameof(TrainingGuyId))]
        public ApplicationUser TrainingGuy { get; set; } = null!;
        [Required]
        public int FoodId { get; set; }
        [ForeignKey(nameof(FoodId))]
        public UserFood Food { get; set; } = null!;
    }
}
