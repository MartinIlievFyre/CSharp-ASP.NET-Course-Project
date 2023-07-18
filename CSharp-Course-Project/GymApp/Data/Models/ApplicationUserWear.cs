using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Data.Models
{
    public class ApplicationUserWear
    {
        [Required]
        public Guid TrainingGuyId { get; set; }
        [ForeignKey(nameof(TrainingGuyId))]
        public ApplicationUser TrainingGuy { get; set; } = null!;
        [Required]
        public int WearId { get; set; }
        [ForeignKey(nameof(WearId))]
        public Wear Wear { get; set; } = null!;
    }
}
