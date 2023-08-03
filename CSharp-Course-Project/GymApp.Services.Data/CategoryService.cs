using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Data;
namespace GymApp.Services.Data
{
    using GymApp.Services.Data.Interfaces;
    using Microsoft.EntityFrameworkCore;

    using GymApp.ViewModels;
    using static GymApp.Common.ExeptionMessages;

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
    }
}
