namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    
    using GymApp.ViewModels;
    using GymApp.Services.Data.Interfaces;

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
        
    }
}
