namespace GymApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using GymApp.Data;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.ExceptionMessages;
    using static GymApp.Common.GeneralApplicationConstants;
    using System.Collections.Generic;
    using GymApp.ViewModels;
    using GymApp.ViewModels.Supplement;
    using GymApp.ViewModels.Accessory;

    public class SupplementService : ISupplementService
    {
        private readonly GymAppDbContext dbContext;
        public SupplementService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<SupplementViewModel>> AllSupplementsAsync()
        {
            List<SupplementViewModel> models = await dbContext
               .Supplements
               .Select(s => new SupplementViewModel()
               {
                   Id = s.Id,
                   Name = s.Name,
                   Manufacturer = s.Manufacturer,
                   Price = s.Price,
                   Type = s.Type,
                   ImageUrl = s.ImageUrl
               })
               .ToListAsync();
            if (models == null)
            {
                throw new ArgumentException(ProductWithIdIsNull);
            }
            return models;
        }

        public async Task<SupplementViewModel> GetSupplementViewModelByIdAsync(string supplementId)
        {
            SupplementViewModel? supplement = await dbContext
                .Supplements
                .Where(s => s.Id == int.Parse(supplementId))
                .Select(s => new SupplementViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Manufacturer = s.Manufacturer,
                    Price = s.Price,
                    Description = s.Description,
                    Benefits = s.Benefits,
                    Ingredients = s.Ingredients,
                    ImageUrl = s.ImageUrl,
                    Type = s.Type,
                })
                .FirstOrDefaultAsync();
            if (supplement == null)
            {
                throw new ArgumentException(ThereIsNoProductWithThisId);
            }
            return supplement;
        }

        public async Task<Supplement> GetSupplemenntByNameAsync(string supplementName)
        {
            Supplement? supplement = await dbContext.Supplements.FirstOrDefaultAsync(p => p.Name == supplementName);
            if (supplement == null)
            {
                throw new ArgumentException(ThereIsNoSupplementWithThisName);
            }

            return supplement;
        }

        public async Task<List<int>> RandomSupplementIdsAsync(string id)
        {
            List<int> randomSupplementsIds = await dbContext.Supplements
                .Where(s => s.Id != int.Parse(id))
                .Select(a => a.Id)
                .OrderBy(x => Guid.NewGuid())
                .Take(3)
                .ToListAsync();
            if (randomSupplementsIds.Count == 0)
            {
                throw new ArgumentException(RandomSupplementIdsAreNull);
            }
            return randomSupplementsIds;
        }

        public async Task<List<SupplementViewModel>> RandomSupplementsWithIdsAsync(List<int> randomSupplementIds)
        {
            List<SupplementViewModel> randomProducts = await dbContext.Supplements
                .Where(s => randomSupplementIds.Contains(s.Id))
                .Select(s => new SupplementViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Manufacturer = s.Manufacturer,
                    Price = s.Price,
                    ImageUrl = s.ImageUrl
                })
                .ToListAsync();
            if (randomProducts == null)
            {
                throw new ArgumentException(RandomSupplementWithIdsAreNull);
            }
            return randomProducts;
        }

        public SupplementDetailsViewModel CreateSupplementDetailsViewModol(List<SupplementViewModel> randomProducts, SupplementViewModel currentProduct)
        {
            SupplementDetailsViewModel viewModel = new SupplementDetailsViewModel()
            {
                CurrentSupplement = currentProduct,
                RandomSupplements = randomProducts
            };
            if (viewModel == null)
            {
                throw new ArgumentException();
            }
            return viewModel;
        }
       

       
    }
}
