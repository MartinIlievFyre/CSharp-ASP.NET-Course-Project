namespace GymApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using System.Collections.Generic;

    using GymApp.Data;
    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.ExceptionMessages;
    using static GymApp.Common.GeneralApplicationConstants;

    public class CartService : ICartService
    {
        private readonly GymAppDbContext dbContext;
        public CartService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAccessoryToCartAsync(Accessory? accessory, Guid userGuidId, string typeOfProduct, int? quantity)
        {
            dbContext.ShoppingCart.Add(new Product()
            {
                Name = accessory!.Name,
                Image = accessory.ImageUrl,
                Price = accessory.Price,
                UserId = userGuidId,
                Quantity = (int)quantity!,
                Size = "",
                Type = typeOfProduct
            });
            await dbContext.SaveChangesAsync();
            Task.Delay(1500).Wait();
        }

        public async Task AddSupplementToCartAsync(Supplement? supplement, Guid userGuidId, string typeOfProduct, int? quantity)
        {
            dbContext.ShoppingCart.Add(new Product()
            {
                Name = supplement!.Name,
                Image = supplement.ImageUrl,
                Price = supplement.Price,
                UserId = userGuidId,
                Quantity = (int)quantity!,
                Size = "",
                Type = typeOfProduct
            });

            await dbContext.SaveChangesAsync();
            Task.Delay(1500).Wait();
        }

        public async Task AddWearToCartAsync(Wear? wear, Guid userGuidId, string typeOfProduct, string size, int? quantity)
        {
            dbContext.ShoppingCart.Add(new Product()
            {
                Name = wear!.Name,
                Image = wear.ImageUrl,
                Price = wear.Price,
                UserId = userGuidId,
                Quantity = (int)quantity!,
                Size = size,
                Type = typeOfProduct
            });
            await dbContext.SaveChangesAsync();
            Task.Delay(1500).Wait();
        }

        public async Task<CartViewModel> CreateNewCartViewModelAsync(string? userId)
        {
            List<Product> products = await GetAllProductsInCartByUserIdAsync(userId);
            
            List<ProductViewModel> modelProducts = GetAllProductViewModelsOnProducts(products);

            decimal sum = GetTotalSumOfAllProducts(modelProducts);

            CartViewModel model = new CartViewModel()
            {
                Products = modelProducts,
                FinalPrice = sum
            };

            if (model == null)
            {
                throw new ArgumentException();
            }
            return model;
        }
        private async Task<List<Product>> GetAllProductsInCartByUserIdAsync(string? userId)
        {
            List<Product> products = await dbContext.
                ShoppingCart.
                Where(p => p.UserId.ToString() == userId).
                ToListAsync();

            return products;
        }//Done

        private List<ProductViewModel> GetAllProductViewModelsOnProducts(List<Product> products)
        {
            List<ProductViewModel> modelProducts = products.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                TotalPrice = p.TotalPrice,
                Size = p.Size,
                Image = p.Image,
                Type = p.Type,
            })
                .ToList();

            return modelProducts;
        }//Done
        private decimal GetTotalSumOfAllProducts(List<ProductViewModel> modelProducts)
        {
            decimal totalSum = modelProducts.Sum(p => p.TotalPrice);
            if (totalSum < 0)
            {
                throw new ArgumentException(TotalSumCanNotBeSmallerThenZero);
            }
            return totalSum;
        }//Done

        public async Task IncreaseProductQuantityWithOne(Product? product, int? quantity)
        {
            product!.Quantity += (int)quantity!;
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsInCartHasProductByNameAndSizeAsync(string productName, string size)
        {
            bool isExistingInCart = await dbContext.ShoppingCart.AnyAsync(s => s.Name == productName && s.Size == size);
            return isExistingInCart;
        }

        public async Task<bool> IsInCartHasProductWithNameAsync(string productName)
        {
            bool isExistingInCart = await dbContext.ShoppingCart.AnyAsync(s => s.Name == productName);
            return isExistingInCart;
        }

        public async Task RemoveAllProductsFromCartAsync(List<Product> products)
        {
            dbContext.ShoppingCart.RemoveRange(products!);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveProductFromCartAsync(Product? product)
        {
            dbContext.ShoppingCart.Remove(product!);
            await dbContext.SaveChangesAsync();
        }
    }
}
