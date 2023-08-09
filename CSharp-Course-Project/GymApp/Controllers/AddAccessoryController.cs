namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GymApp.Data.Models;
    using GymApp.ViewModels.Accessory;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.NotificationMessagesConstants;
    using static GymApp.Common.EntityValidationConstants.RolesConstants;

    [Authorize(Roles = NameOfRoleAdmin)]
    public class AddAccessoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAccessoryService accessoryService;
        public AddAccessoryController(IAccessoryService accessoryService, ICategoryService categoryService)
        {
            this.accessoryService = accessoryService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult AddAccessory()
        {
            try
            {
                AddAccessoryViewModel model = accessoryService.CreateAddAccessoryViewModel();

                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddAccessory(AddAccessoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                Accessory accessory = await accessoryService.CreateAccessoryAsync(model);

                TempData["Success"] = SuccessfullyCreatedAccessory;
                return RedirectToAction("Accessories", "Accessory");

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("AddAccessory", "AddAccessory");
            }
        }
    }
}
