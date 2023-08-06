namespace GymApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using GymApp.Data;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.ExceptionMessages;
    using System.Collections.Generic;
    using GymApp.ViewModels;

    public class WearService : IWearService
    {
        private readonly GymAppDbContext dbContext;
        public WearService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<WearViewModel?> GetWearViewModelByIdAsync(string wearId)
        {
            WearViewModel? currentProduct = await dbContext
           .Clothes
           .Where(c => c.Id == int.Parse(wearId))
           .Select(c => new WearViewModel()
           {
               Id = c.Id,
               Name = c.Name,
               Price = c.Price,
               Description = c.Description,
               Color = c.Color,
               Size = c.Size,
               Fabric = c.Fabric,
               WearCategory = c.WearCategory.Name,
               ImageUrl = c.ImageUrl,
               Type = c.Type

           })
           .FirstOrDefaultAsync();
            if (currentProduct == null)
            {
                throw new ArgumentException(ThereIsNoProductWithThisId);
            }
            return currentProduct;
        }

        public async Task<Wear?> GetWearByNameAsync(string wearName)
        {
            Wear? wear = await dbContext.Clothes.FirstOrDefaultAsync(a => a.Name == wearName);

            if (wear == null)
            {
                throw new ArgumentException(ThereIsNoWearWithThisName);
            }

            return wear;
        }

        public async Task<List<WearViewModel>?> GetWearViewModelsByWearCategoryIdAsync(string wearCategoryId)
        {
            WearCategory? wearCategory= await dbContext.WearCategories.FirstOrDefaultAsync(wc => wc.Id.ToString() == wearCategoryId);
            if (wearCategory == null)
            {
                throw new ArgumentException(ThereIsNoCategoryWithThisId);
            }
            var clothes = await dbContext
                .Clothes
                .Where(c => c.WearCategoryId == wearCategory.Id)
                .Select(c => new WearViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    ImageUrl = c.ImageUrl,
                    Type = c.Type

                })
                .ToListAsync();
            if (clothes.Count == 0)
            {
                throw new ArgumentException(ThereAreNoClothesWithThisCategoryId);
            }
            return clothes;
        }

        public async Task<List<int>> GetThreeRandomProductsIdsAsync(string id)
        {
            List<int> randomClothesIds = await dbContext.Clothes
                    .Where(c => c.Id != int.Parse(id))
                    .Select(c => c.Id)
                    .OrderBy(x => Guid.NewGuid())
                    .Take(3)
                    .ToListAsync();
            if (randomClothesIds.Count == 0)
            {
                throw new ArgumentException(RandomClothesIdsAreNull);
            }
            return randomClothesIds;
        }

        public async Task<List<WearViewModel>> GetThreeRandomProductsByIdsAsync(List<int> productsIds)
        {
            List<WearViewModel> randomProducts = await dbContext.Clothes
                    .Where(c => productsIds.Contains(c.Id))
                    .Select(c => new WearViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Price = c.Price,
                        ImageUrl = c.ImageUrl
                    })
                    .ToListAsync();
            if (randomProducts.Count == 0)
            {
                throw new ArgumentException(RandomClothesWithIdsAreNull);
            }
            return randomProducts;
        }

        public ClothingDetailsViewModel CreateNewClothingDetailsViewModelAsync(WearViewModel? currentProduct, List<WearViewModel> randomProducts)
        {
            ClothingDetailsViewModel viewModel = new ClothingDetailsViewModel()
            {
                CurrentClothing = currentProduct!,
                RandomClothes = randomProducts
            };
            return viewModel;
        }
    }
}
