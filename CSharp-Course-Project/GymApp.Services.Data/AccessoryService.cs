namespace GymApp.Services.Data
{
    using GymApp.Services.Data.Interfaces;
    using GymApp.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using GymApp.Data;
    using static GymApp.Common.ExeptionMessages;
    using System.Collections.Generic;

    public class AccessoryService : IAccessoryService
    {
        private readonly GymAppDbContext dbContext;
        public AccessoryService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<AccessoryViewModel>> AllAccessoriesAsync()
        {
            var accessories = await dbContext
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
            if (accessories == null)
            {
                throw new ArgumentException(ThereAreNoProducts);
            }
            return accessories;
        }

        public async Task<AccessoryViewModel> GetProductByIdAsync(string id)
        {
            var currentProduct = await dbContext
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

        public async Task<List<int>> RandomAccessoryIdsAsync(string id)
        {
            var randomAccessoryIds = await dbContext.Accessories
                   .Where(a => a.Id != int.Parse(id))
                   .Select(a => a.Id)
                   .OrderBy(x => Guid.NewGuid())
                   .Take(3)
                   .ToListAsync();
            if (randomAccessoryIds == null)
            {
                throw new ArgumentException(RandomAccessoryIdsAreNull);
            }
            return randomAccessoryIds;
        }

        public async Task<List<AccessoryViewModel>> RandomAccessoriesWithIdsAsync(List<int> randomAccessoryIds)
        {
            var randomProducts = await dbContext
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
            if (randomProducts == null)
            {
                throw new ArgumentException(RandomAccessoryWithIdsAreNull);
            }
            return randomProducts;
        }
    }
}
