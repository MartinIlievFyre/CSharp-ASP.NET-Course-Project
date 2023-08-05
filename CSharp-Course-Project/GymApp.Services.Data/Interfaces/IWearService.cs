namespace GymApp.Services.Data.Interfaces
{
    using GymApp.Data.Models;
    using GymApp.ViewModels;

    public interface IWearService
    {
        Task<Wear?> GetWearByNameAsync(string wearName);
        Task<WearViewModel?> GetWearViewModelByIdAsync(string wearId);
        Task<List<WearViewModel>?> GetWearViewModelsByWearCategoryIdAsync(string wearCategoryId);
        Task<List<int>> GetThreeRandomProductsIdsAsync(string id);
        Task<List<WearViewModel>> GetThreeRandomProductsByIdsAsync(List<int> productsIds);
        ClothingDetailsViewModel CreateNewClothingDetailsViewModelAsync(WearViewModel? currentProduct, List<WearViewModel> randomProducts);

    }
}
