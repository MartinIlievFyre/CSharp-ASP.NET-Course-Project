namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GymApp.Common.EntityValidationConstants.WearCategory;

    public class WearCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
