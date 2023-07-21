using System.ComponentModel.DataAnnotations;

namespace GymApp.Models
{
    public class SupplementViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Benefits { get; set; } = null!;

        public string Ingredients { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
