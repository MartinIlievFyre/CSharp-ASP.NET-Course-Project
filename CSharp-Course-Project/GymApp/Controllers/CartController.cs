using GymApp.Data;
using GymApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Xml.Linq;

namespace GymApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly GymAppDbContext dbContext;
        public CartController(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> MyCartItems()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var products = await dbContext.ShoppingCart.Where(p => p.UserId.ToString() == userId).ToListAsync();

            var modelProducts = products.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                TotalPrice = p.TotalPrice,
                Size = p.Size,
                Image = p.Image,
                Type = p.Type,
            })
                .ToList();

            var sum = modelProducts.Sum(p => p.TotalPrice);

            var model = new CartViewModel()
            {
                Products = modelProducts,
                FinalPrice = sum
            };

            return View(model);
        }
    }
}
