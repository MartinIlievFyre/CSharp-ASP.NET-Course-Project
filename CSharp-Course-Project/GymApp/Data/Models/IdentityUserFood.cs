using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Data.Models
{
    public class IdentityUserFood
    {
        [Required]
        public string TrainingGuyId { get; set; } = null!;
        [ForeignKey(nameof(TrainingGuyId))]
        public IdentityUser TrainingGuy { get; set; } = null!;
        [Required]
        public int FoodId { get; set; }
        [ForeignKey(nameof(FoodId))]
        public Food Food { get; set; } = null!;
    }
}
