using GymApp.Data;
using GymApp.Data.Models;
using GymApp.Services.Data.Interfaces;
using GymApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using static GymApp.Common.ExceptionMessages;


namespace GymApp.Services.Data
{
    public class ProductService : IProductService
    {
        private readonly GymAppDbContext dbContext;
        public ProductService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProductsInCartAsync(Guid? userGuidId)
        {
            if (userGuidId == null)
            {
                throw new ArgumentException(ThereIsNoUserWithThisId);
            }
            List<Product> products = await dbContext.ShoppingCart.Select(p => new Product()
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Size = p.Size,
                Price = p.Price,
                Quantity = p.Quantity,
                Type = p.Type,
                User = p.User,
                UserId = (Guid)userGuidId!
            })
                .ToListAsync();
            if (products.Count == 0)
            { 
                throw new ArgumentException(ThereAreNoProductsInCart);
            }
            return products;
        }


        public async Task<Product?> GetProductFromShoppingCartByNameAndSizeAsync(string productName, string size)
        {
            Product? product = await dbContext.ShoppingCart.Where(p => p.Name == productName && p.Size!.ToUpper() == size.ToUpper()).FirstOrDefaultAsync();
            if (product == null)
            {
                throw new ArgumentException(ThereIsNoProductWithThisNameAndSizeInShoppingCart);
            }
            await dbContext.SaveChangesAsync();
            Task.Delay(1500).Wait();
            return product;
        }

        public async Task<Product?> GetProductFromShoppingCartByNameAsync(string productName)
        {
            Product? product = await dbContext.ShoppingCart.Where(p => p.Name == productName).FirstOrDefaultAsync();
            if (product == null)
            {
                throw new ArgumentException(ThereIsNoProductWithThisNameInShoppingCart);
            }
            await dbContext.SaveChangesAsync();
            Task.Delay(1500).Wait();
            return product;
        }

        public async Task<Product?> GetProductFromShoppingCartByProductIdAndUserIdAsync(int productId, string? userId)
        {
            Product? product = await dbContext
                .ShoppingCart
                .FirstOrDefaultAsync(ue => ue.Id == productId && ue.UserId.ToString() == userId);
            if (product == null)
            {
                throw new ArgumentException(ThereIsNoProductWithThisIdAndUserIdInShoppingCart);
            }
            return product;
        }
    }
}
