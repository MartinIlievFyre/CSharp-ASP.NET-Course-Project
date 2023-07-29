namespace GymApp.Models
{
    public class ListOfCartItemsViewModel
    {
        public ICollection<AccessoryViewModel> Accessories { get; set; } = null!;
        public ICollection<SupplementViewModel> Supplements { get; set; } = null!;
        public ICollection<WearViewModel> Clothes { get; set; } = null!;

    }
}
