namespace GymApp.Services.Data
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using GymApp.Data;
    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.ExceptionMessages;

    public class AccessoryService : IAccessoryService
    {
        private readonly GymAppDbContext dbContext;
        public AccessoryService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<AccessoryViewModel> GetAccessoryViewModelByIdAsync(string id)
        {
            AccessoryViewModel? currentProduct = await dbContext
             .Accessories
             .Where(a => a.Id == int.Parse(id))
             .Select(a => new AccessoryViewModel()
             {
                 Id = a.Id,
                 Name = a.Name,
                 Manufacturer = a.Manufacturer,
                 Price = a.Price,
                 Description = a.Description,
                 Benefits = a.Benefits,
                 ImageUrl = a.ImageUrl,
                 Type = a.Type
             })
             .FirstOrDefaultAsync();

            if (currentProduct == null)
            {
                throw new ArgumentException(ProductWithIdIsNull);
            }
            return currentProduct!;
        }

        public async Task<Accessory?> GetAccessoryByNameAsync(string accessoryName)
        {
            Accessory? accessory = await dbContext.Accessories.FirstOrDefaultAsync(a => a.Name == accessoryName);

            if (accessory == null)
            {
                throw new ArgumentException(ThereIsNoAccessoryWithThisName);
            }

            return accessory;
        }

        public async Task<IEnumerable<AccessoryViewModel>> AllAccessoriesAsync()
        {
            List<AccessoryViewModel> accessories = await dbContext
                .Accessories
                .Select(a => new AccessoryViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Manufacturer = a.Manufacturer,
                    Price = a.Price,
                    ImageUrl = a.ImageUrl,
                    Type = a.Type,
                })
                .ToListAsync();
            if (accessories.Count == 0)
            {
                throw new ArgumentException(ThereAreNoProducts);
            }
            return accessories;
        }

        public async Task<List<int>> RandomAccessoryIdsAsync(string id)
        {
            List<int> randomAccessoryIds = await dbContext.Accessories
                   .Where(a => a.Id != int.Parse(id))
                   .Select(a => a.Id)
                   .OrderBy(x => Guid.NewGuid())
                   .Take(3)
                   .ToListAsync();
            if (randomAccessoryIds.Count == 0)
            {
                throw new ArgumentException(RandomAccessoryIdsAreNull);
            }
            return randomAccessoryIds;
        }

        public async Task<List<AccessoryViewModel>> RandomAccessoriesWithIdsAsync(List<int> randomAccessoryIds)
        {
            List<AccessoryViewModel> randomProducts = await dbContext
                    .Accessories
                    .Where(a => randomAccessoryIds.Contains(a.Id))
                    .Select(a => new AccessoryViewModel()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Manufacturer = a.Manufacturer,
                        Price = a.Price,
                        ImageUrl = a.ImageUrl
                    })
                    .ToListAsync();
            if (randomProducts.Count == 0)
            {
                throw new ArgumentException(RandomAccessoryWithIdsAreNull);
            }
            return randomProducts;
        }

        public AccessoryDetailsViewModel CreateAccessoryDetailsViewModel(AccessoryViewModel currentProduct, List<AccessoryViewModel> randomProducts)
        {
            var viewModel = new AccessoryDetailsViewModel()
            {
                CurrentAccessory = currentProduct,
                RandomAccessories = randomProducts
            };
            if (viewModel == null)
            {
                throw new ArgumentException();
            }
            return viewModel;
        }

        public async Task<Accessory> GetAccessoryByIdAsync(int accessoryId)
        {
            Accessory? accessory = await dbContext.Accessories.FirstOrDefaultAsync(e => e.Id == accessoryId);

            if (accessory == null)
            {
                throw new ArgumentException(ThereIsNoAccessoryWithThisId);
            }

            return accessory;
        }

        public async Task DeleteAccessoryAsync(Accessory accessory)
        {
            dbContext.Accessories.Remove(accessory);
            await dbContext.SaveChangesAsync();
        }
    }
}
