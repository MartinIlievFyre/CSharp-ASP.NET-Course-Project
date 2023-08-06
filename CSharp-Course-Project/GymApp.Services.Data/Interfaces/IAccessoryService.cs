namespace GymApp.Services.Data.Interfaces
{
    using GymApp.ViewModels;
    using GymApp.Data.Models;

    public interface IAccessoryService
    {
        Task<IEnumerable<AccessoryViewModel>> AllAccessoriesAsync();
        Task<Accessory?> GetAccessoryByNameAsync(string accessoryName);
        Task<AccessoryViewModel> GetAccessoryByIdAsync(string id);
        Task<List<int>> RandomAccessoryIdsAsync(string id);
        Task<List<AccessoryViewModel>> RandomAccessoriesWithIdsAsync(List<int> randomAccessoryIds);
        AccessoryDetailsViewModel CreateAccessoryDetailsViewModel(AccessoryViewModel currentProduct, List<AccessoryViewModel> randomProducts);
    }
}
