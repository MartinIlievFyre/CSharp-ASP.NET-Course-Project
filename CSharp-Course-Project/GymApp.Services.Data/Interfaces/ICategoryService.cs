using GymApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();
        Task<ICollection<CategoryViewModel>> AllWearCategoriesAsync();
        Task<string> GetCategoryNameByCategoryIdAsync(int id);
        CategoryListViewModel CreateCategoryListViewModel(ICollection<CategoryViewModel> categories);
    }
}
