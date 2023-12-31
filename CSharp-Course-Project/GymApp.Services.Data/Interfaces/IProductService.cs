﻿namespace GymApp.Services.Data.Interfaces
{
    using GymApp.ViewModels;
    using GymApp.Data.Models;

    public interface IProductService
    {
        Task<List<Product>> GetAllProductsInCartAsync(Guid? userGuidId);

        Task<Product?> GetProductFromShoppingCartByNameAsync(string productName);

        Task<Product?> GetProductFromShoppingCartByNameAndSizeAsync(string productName, string size);

        Task<Product?> GetProductFromShoppingCartByProductIdAndUserIdAsync(int productId, string? userId);
    }
}
