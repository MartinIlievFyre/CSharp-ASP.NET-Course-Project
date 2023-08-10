namespace GymApp.Services.Data.Interfaces
{
    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.ViewModels.Accessory;
    using GymApp.ViewModels.Supplement;

    public interface ISupplementService
    {
        Task<Supplement> GetSupplemenntByNameAsync(string supplementName);
        Task<SupplementViewModel> GetSupplementViewModelByIdAsync(string supplementId);
        Task<IEnumerable<SupplementViewModel>> AllSupplementsAsync();
        Task<List<int>> RandomSupplementIdsAsync(string id);
        Task<List<SupplementViewModel>> RandomSupplementsWithIdsAsync(List<int> randomSupplementIds);
        SupplementDetailsViewModel CreateSupplementDetailsViewModol(List<SupplementViewModel> randomProducts, SupplementViewModel currentProduct);
    }
}
