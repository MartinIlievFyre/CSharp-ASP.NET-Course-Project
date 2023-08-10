namespace GymApp.Services.Data.Interfaces
{
    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.ViewModels.Accessory;
    using GymApp.ViewModels.Clothing;

    public interface IAccessoryService
    {
        Task<IEnumerable<AccessoryViewModel>> AllAccessoriesAsync();
        
        Task<Accessory?> GetAccessoryByNameAsync(string accessoryName);
        Task<AccessoryViewModel> GetAccessoryViewModelByIdAsync(string id);
        Task<List<int>> RandomAccessoryIdsAsync(string id);
        Task<List<AccessoryViewModel>> RandomAccessoriesWithIdsAsync(List<int> randomAccessoryIds);
        AccessoryDetailsViewModel CreateAccessoryDetailsViewModel(AccessoryViewModel currentProduct, List<AccessoryViewModel> randomProducts);

    }
}
