namespace GymApp.Data.Models
{
using System.ComponentModel.DataAnnotations;
    using static ValidationConstants.Note;
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        public ICollection<IdentityUserExercise> UsersExercises { get; set; } = new List<IdentityUserExercise>();

    }
}
