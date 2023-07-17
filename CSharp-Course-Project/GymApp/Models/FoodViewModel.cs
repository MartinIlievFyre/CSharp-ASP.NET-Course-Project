namespace GymApp.Models
{
    using GymApp.Data.Models;

    public class FoodViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Calories { get; set; }

        public double Carbs { get; set; }

        public double Fat { get; set; }

        public double Protein { get; set; }
        public int Grams { get; set; }

        public ICollection<ApplicationUserFood> UsersFood { get; set; } = new List<ApplicationUserFood>();

    }
}
