namespace GymApp.Services.Data.Interfaces
{
    using GymApp.ViewModels;
    using GymApp.Data.Models;

    public interface ICartService
    {
        decimal GetTotalSumOfAllProducts(List<ProductViewModel> modelProducts);

        CartViewModel CreateNewCartViewModel(List<ProductViewModel> modelProducts, decimal sum);

        Task<bool> IsInCartHasProductByNameAsync(string productName);

        Task<bool> IsInCartHasProductByNameAndSizeAsync(string productName, string size);

        Task AddSupplementToCartAsync(Supplement? supplement, Guid userGuidId, string typeOfProduct, int? quantity);

        Task AddAccessoryToCartAsync(Accessory? accessory, Guid userGuidId, string typeOfProduct, int? quantity);

        Task AddWearToCartAsync(Wear? wear, Guid userGuidId, string typeOfProduct, string size, int? quantity);

        Task IncreaseProductQuantityWithOne(Product? product, int? quantity);
        Task RemoveProductFromCartAsync(Product? product);
        Task RemoveAllProductsFromCartAsync(List<Product> products);
    }
}
