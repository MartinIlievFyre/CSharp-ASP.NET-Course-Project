namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GymApp.ViewModels;
    using GymApp.Services.Data.Interfaces;

    public class ClothingController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IWearService wearService;

        public ClothingController(ICategoryService categoryService, IWearService wearService)
        {
            this.categoryService = categoryService;
            this.wearService = wearService;
        }
        [HttpGet]
        public async Task<IActionResult> Clothes()
        {
            try
            {
                ICollection<CategoryViewModel> categories = await categoryService.AllWearCategoriesAsync();

                CategoryListViewModel models = categoryService.CreateCategoryListViewModel(categories);
                return View(models);

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetClothing(string id)
        {
            try
            {
                List<WearViewModel>? clothes = await wearService.GetWearViewModelsByWearCategoryIdAsync(id);
                return View(clothes);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ClothingDetails(string id)
        {
            try
            {
                WearViewModel? currentProduct = await wearService.GetWearViewModelByIdAsync(id);

                List<int> randomClothesIds = await wearService.GetThreeRandomProductsIdsAsync(id);

                List<WearViewModel> randomProducts = await wearService.GetThreeRandomProductsByIdsAsync(randomClothesIds);

                ClothingDetailsViewModel viewModel = wearService.CreateNewClothingDetailsViewModelAsync(currentProduct, randomProducts);

                return View(viewModel);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
