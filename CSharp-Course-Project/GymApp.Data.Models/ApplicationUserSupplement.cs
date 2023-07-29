using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Models
{
    public class ApplicationUserSupplement
    {

        [Required]
        public Guid TrainingGuyId { get; set; }
        [ForeignKey(nameof(TrainingGuyId))]
        public ApplicationUser TrainingGuy { get; set; } = null!;
        [Required]
        public int SupplementId { get; set; }
        [ForeignKey(nameof(SupplementId))]
        public Supplement Supplement { get; set; } = null!;
    }
}
