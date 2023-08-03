using GymApp.Data.Models;
using GymApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Services.Data.Interfaces
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodViewModel>> AllFoodsWithDefaultValuesAsync();

        Task<IEnumerable<FoodViewModel>> AllUserFoodsByUserIdAsync(string? userId);

        Task<Food> AllFoodsWithDefaultValuesByIdAsync(int foodId);
        Task<UserFood> AllUserFoodsByIdAsync(int foodId);
    }
}
