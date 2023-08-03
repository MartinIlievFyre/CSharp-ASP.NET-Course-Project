using GymApp.Common;
using GymApp.Data;
using GymApp.Data.Models;
using GymApp.Services.Data.Interfaces;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace GymApp.Controllers
{
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
                //To Do
                return NotFound();
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

                var viewModel = new AccessoryDetailsViewModel()
                {
                    CurrentAccessory = currentProduct,
                    RandomAccessories = randomProducts
                };
                return View(viewModel);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                //TO DO redirect 
                return NotFound();
            }
        }
    }
}
