namespace GymApp.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }
        public string Image { get; set; } = null!;

        public string? Size { get; set; }
    }
}
