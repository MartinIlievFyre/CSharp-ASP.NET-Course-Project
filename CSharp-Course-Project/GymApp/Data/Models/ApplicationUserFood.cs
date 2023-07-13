using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Data.Models
{
    public class ApplicationUserFood
    {
        [Required]
        public Guid TrainingGuyId { get; set; }
        [ForeignKey(nameof(TrainingGuyId))]
        public ApplicationUser TrainingGuy { get; set; } = null!;
        [Required]
        public int FoodId { get; set; }
        [ForeignKey(nameof(FoodId))]
        public Food Food { get; set; } = null!;
    }
}
