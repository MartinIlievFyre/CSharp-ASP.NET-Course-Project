namespace GymApp.ViewModels
{
    public class SupplementDetailsViewModel
    {
        public SupplementViewModel CurrentSupplement { get; set; } = null!;
        public List<SupplementViewModel> RandomSupplements { get; set; } = null!;
    }
}
