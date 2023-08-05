using GymApp.Data.Models;
using GymApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsInCartAsync(Guid? userGuidId);
        Task<List<Product>> GetAllProductsInCartByUserIdAsync(string? userId);

        List<ProductViewModel> GetAllProductViewModelsOnProducts(List<Product> products);

        Task<Product?> GetProductFromShoppingCartByNameAsync(string productName);

        Task<Product?> GetProductFromShoppingCartByNameAndSizeAsync(string productName, string size);

        Task<Product?> GetProductFromShoppingCartByProductIdAndUserIdAsync(int productId, string? userId);
    }
}
