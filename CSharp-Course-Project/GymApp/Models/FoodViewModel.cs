namespace GymApp.Models
{
    using GymApp.Data.Models;

    public class FoodViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Calories { get; set; }

        public int Carbs { get; set; }

        public int Fat { get; set; }

        public int Protein { get; set; }

        public ICollection<IdentityUserFood> UsersFood { get; set; } = new List<IdentityUserFood>();

    }
}
