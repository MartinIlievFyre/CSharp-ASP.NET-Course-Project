namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GymApp.Services.Data.Interfaces;
    using GymApp.ViewModels;

    [Authorize]
    public class AccessoryController : Controller
    {
        private readonly IAccessoryService accessoryService;
        public AccessoryController( IAccessoryService accessoryService)
        {
            this.accessoryService = accessoryService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Accessories()
        {
            try
            {
                IEnumerable<AccessoryViewModel> viewModels = await accessoryService.AllAccessoriesAsync();
                return View(viewModels);

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AccessoryDetails(string id)
        {
            try
            {
                AccessoryViewModel currentProduct = await accessoryService.GetProductByIdAsync(id);

                if (currentProduct == null)
                {
                    return NotFound();
                }

                // Get three random accessory IDs (excluding the current product ID)
                List<int> randomAccessoryIds = await accessoryService.RandomAccessoryIdsAsync(id);
                

                // Get the details of three random products
                var randomProducts = await accessoryService.RandomAccessoriesWithIdsAsync(randomAccessoryIds);

                var viewModel = accessoryService.CreateAccessoryDetailsViewModel(currentProduct, randomProducts);

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
