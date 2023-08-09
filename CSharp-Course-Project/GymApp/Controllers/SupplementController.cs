namespace GymApp.Controllers
{

    using GymApp.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using GymApp.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using GymApp.Infrastructure.Extensions;
    using GymApp.Services.Data;
    using GymApp.Data.Models;
    using static GymApp.Common.NotificationMessagesConstants;
    [Authorize]
    public class SupplementController : Controller
    {
        private readonly ISupplementService supplementService;

        public SupplementController(ISupplementService supplementService)
        {
            this.supplementService = supplementService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Supplements()
        {
            try
            {
                IEnumerable<SupplementViewModel> models = await supplementService.AllSupplementsAsync();
                return View(models);

            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> SupplementDetails(string id)
        {
            try
            {
                SupplementViewModel? currentProduct = await supplementService.GetSupplementViewModelByIdAsync(id);

                List<int> randomSupplementsIds = await supplementService.RandomSupplementIdsAsync(id);

                List<SupplementViewModel> randomProducts = await supplementService.RandomSupplementsWithIdsAsync(randomSupplementsIds);

                SupplementDetailsViewModel viewModel = supplementService.CreateSupplementDetailsViewModol(randomProducts, currentProduct);

                return View(viewModel);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        //[Authorize(Roles = NameOfRoleAdmin)]
        public async Task<IActionResult> DeleteSupplement(int id)
        {
            try
            {
                Supplement supplement = await supplementService.GetSupplementByidAsync(id);

                await supplementService.DeleteSupplementAsync(supplement);
                
                TempData["Error"] = SuccessfullyDeletedSupplement;
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
