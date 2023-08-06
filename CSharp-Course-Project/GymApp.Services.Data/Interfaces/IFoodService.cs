namespace GymApp.Services.Data.Interfaces
{
    using GymApp.ViewModels;
    using GymApp.Data.Models;

    public interface IFoodService
    {
        Task<IEnumerable<FoodViewModel>> AllFoodsWithDefaultValuesAsync();

        Task<IEnumerable<FoodViewModel>> AllUserFoodsByUserIdAsync(string? userId);

        Task<Food> AllFoodsWithDefaultValuesByIdAsync(int foodId);
        Task<UserFood> AllUserFoodsByIdAsync(int foodId);
        Task<ApplicationUserFood?> GetApplicationUserFoodAsync(int foodId, string? userId);
        Task<ApplicationUserFood?> GetUserFromApplicationUserFoodByUserIdAsync(string? userId);

        Task AddingMacrosToAnExistingFoodAsync(UserFood? food, Food? foodWithDefaultValues, double weightMultiplier, int weightGrams);
        Task AddingNewFoodToListAsync(UserFood? food, Food? foodWithDefaultValues, double weightMultiplier, int weightGrams, int foodId,Guid userGuidId);
        Task RemoveFoodFromListAsync(ApplicationUserFood? food);
        Task<Food> CreateFoodWithDefaultValuesAsync(AddFoodViewModel model);
        Task<UserFood> CreateFoodThatUserCanModifyAsync(AddFoodViewModel model);
    }
}
