namespace GymApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using GymApp.Data;
    using GymApp.ViewModels;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.ExceptionMessages;
    using System.Collections.Generic;

    public class CategoryService : ICategoryService
    {
        private readonly GymAppDbContext dbContext;
        public CategoryService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
        {
            var categories = await dbContext.Categories.Select(e => new CategoryViewModel()
            {
                Id = e.Id,
                Name = e.Name
            })
                .ToListAsync();
            if (categories == null)
            {
                throw new ArgumentException(ThereAreNoCategories);
            }
            return categories;
        }

        public async Task<ICollection<CategoryViewModel>> AllWearCategoriesAsync()
        {
            var categories = await dbContext.WearCategories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
            if (categories == null)
            {
                throw new ArgumentException(ThereAreNoCategories);
            }
            return categories;
        }

        public CategoryListViewModel CreateCategoryListViewModel(ICollection<CategoryViewModel> categories)
        {
            CategoryListViewModel models = new CategoryListViewModel()
            {
                Categories = categories
            };
            if (categories == null)
            {
                throw new ArgumentException();
            }
            return models;
        }

        public async Task<string> GetCategoryNameByCategoryIdAsync(int id)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                throw new ArgumentException(ThereIsNoCategoryWithThisId);
            }
            return category.Name;
        }
    }
}
