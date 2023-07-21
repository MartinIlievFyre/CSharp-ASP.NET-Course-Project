namespace GymApp.Data.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Guid UserId { get; set; } 
        public ICollection<Wear> Clothes { get; set; } = new List<Wear>();
        //public ICollection<Accessory> Accessories { get; set; } = new List<Accessory>();
        //public ICollection<Supplement> Supplements { get; set; } = new List<Supplement>();
    }
}
