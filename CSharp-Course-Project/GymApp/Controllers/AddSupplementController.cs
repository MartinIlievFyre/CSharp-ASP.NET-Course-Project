namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GymApp.Data.Models;
    using GymApp.ViewModels.Supplement;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.NotificationMessagesConstants;
    using static GymApp.Common.EntityValidationConstants.RolesConstants;

    [Authorize(Roles = NameOfRoleAdmin)]
    public class AddSupplementController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ISupplementService supplementService;
        public AddSupplementController(ISupplementService supplementService, ICategoryService categoryService)
        {
            this.supplementService = supplementService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult AddSupplement()
        {
            try
            {
                AddSupplementViewModel model = supplementService.CreateAddSupplementViewModel();

                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddSupplement(AddSupplementViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                Supplement supplement = await supplementService.CreateSupplementAsync(model);

                TempData["Success"] = SuccessfullyCreatedSupplement;
                return RedirectToAction("Supplements", "Supplement");

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Supplements", "Supplement");
            }
        }
    }
}
