namespace GymApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using GymApp.Data;
    using GymApp.ViewModels;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.ExceptionMessages;
    using System.Collections.Generic;
    using GymApp.Data.Models;
    using GymApp.ViewModels.WearCategory;

    public class CategoryService : ICategoryService
    {
        private readonly GymAppDbContext dbContext;
        public CategoryService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
        {
            List<CategoryViewModel> categories = await dbContext.Categories.Select(e => new CategoryViewModel()
            {
                Id = e.Id,
                Name = e.Name
            })
                .ToListAsync();
            if (categories.Count == 0)
            {
                throw new ArgumentException(ThereAreNoCategories);
            }
            return categories;
        }

        public async Task<ICollection<WearCategoryViewModel>> AllWearCategoriesAsync()
        {
            List<WearCategoryViewModel> categories = await dbContext.WearCategories
                .Select(c => new WearCategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
            if (categories.Count == 0)
            {
                throw new ArgumentException(ThereAreNoCategories);
            }
            return categories;
        }

        public async Task<string> GetCategoryNameByCategoryIdAsync(int id)
        {
            Category? category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                throw new ArgumentException(ThereIsNoCategoryWithThisId);
            }
            return category.Name;
        }

        public CategoryListViewModel CreateCategoryListViewModel(ICollection<CategoryViewModel> categories)
        {
            if (categories.Count == 0)
            {
                throw new ArgumentException();
            }
            CategoryListViewModel models = new CategoryListViewModel()
            {
                Categories = categories
            };
            return models;
        }
        public CategoryListExerciseViewModel CreateCategoryListExerciseViewModel(IEnumerable<CategoryViewModel> categories, List<ExerciseViewModel> exercises)
        {
            if (categories.Count() == 0)
            {
                throw new ArgumentException();
            }
            CategoryListExerciseViewModel models = new CategoryListExerciseViewModel()
            {
                Categories = (ICollection<CategoryViewModel>)categories,
                Exercises = exercises
            };
            return models;
        }

        public WearCategoryListViewModel CreateWearCategoryListViewModel(ICollection<WearCategoryViewModel> categories)
        {
            if (categories.Count == 0)
            {
                throw new ArgumentException();
            }
            WearCategoryListViewModel models = new WearCategoryListViewModel()
            {
                Categories = categories
            };
            return models;
        }
    }
}
