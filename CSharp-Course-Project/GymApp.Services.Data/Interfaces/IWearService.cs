namespace GymApp.Services.Data.Interfaces
{
    using GymApp.Data.Models;
    using GymApp.ViewModels;
    using GymApp.ViewModels.Clothing;
    using GymApp.ViewModels.WearCategory;

    public interface IWearService
    {
        Task<Wear?> GetWearByNameAsync(string wearName);
        Task<Wear> GetWearByidAsync(int wearId);
        AddWearViewModel CreateAddWearViewModel(List<WearCategoryViewModel> categories);
        Task<Wear> CreateWearAsync(AddWearViewModel model);
        Task<WearViewModel?> GetWearViewModelByIdAsync(string wearId);
        Task<List<WearViewModel>?> GetWearViewModelsByWearCategoryIdAsync(string wearCategoryId);
        Task<List<int>> GetThreeRandomProductsIdsAsync(string id);
        Task<List<WearViewModel>> GetThreeRandomProductsByIdsAsync(List<int> productsIds);
        ClothingDetailsViewModel CreateNewClothingDetailsViewModelAsync(WearViewModel? currentProduct, List<WearViewModel> randomProducts);
        Task DeleteWearAsync(Wear wear);
    }
}
