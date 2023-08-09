namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.NotificationMessagesConstants;
    using static GymApp.Common.EntityValidationConstants.RolesConstants;

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
                AccessoryViewModel currentProduct = await accessoryService.GetAccessoryViewModelByIdAsync(id);

                List<int> randomAccessoryIds = await accessoryService.RandomAccessoryIdsAsync(id);
                
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
        [HttpPost]
        [Authorize(Roles = NameOfRoleAdmin)]
        public async Task<IActionResult> DeleteAccessory(int id)
        {
            try
            {
                Accessory accessory = await accessoryService.GetAccessoryByIdAsync(id);

                await accessoryService.DeleteAccessoryAsync(accessory);

                TempData["Error"] = SuccessfullyDeletedAccessory;
                return RedirectToAction("Accessories", "Accessory");
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Accessories", "Accessory");

            }
        }
    }
}
