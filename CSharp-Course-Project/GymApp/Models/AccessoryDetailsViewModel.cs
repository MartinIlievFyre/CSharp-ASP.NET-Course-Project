namespace GymApp.Models
{
    public class AccessoryDetailsViewModel
    {
        public AccessoryViewModel CurrentAccessory { get; set; } = null!;
        public List<AccessoryViewModel> RandomAccessories { get; set; } = null!;
    }
}
