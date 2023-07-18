namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GymApp.Common.EntityValidationConstants.WearSizeCategory;

    public class WearSizeCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
