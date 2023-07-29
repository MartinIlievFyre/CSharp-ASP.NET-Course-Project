namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GymApp.Common.EntityValidationConstants.WearCategory;

    public class WearCategory
    {
        public WearCategory()
        {
            Clothes = new List<Wear>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public ICollection<Wear> Clothes { get; set; }

    }
}
