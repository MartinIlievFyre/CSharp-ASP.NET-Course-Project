using GymApp.Data;
using GymApp.Data.Models;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static GymApp.Common.GeneralApplicationConstants;
namespace GymApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        //private readonly IShoppingCartService shoppingCartService;
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
        [HttpPost]
        public async Task<IActionResult> AddToCart(string name, string typeOfProduct, string size, int? quantity)
        {
            try
            {

                if (quantity.HasValue && quantity > 0)
                {
                    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Guid userGuidId;
                    Guid.TryParse(userId, out userGuidId);

                    Accessory? accessory;
                    Supplement? supplement;
                    Wear? wear;

                    if (typeOfProduct == TypeProductSupplement)
                    {
                        supplement = await dbContext.Supplements.FirstOrDefaultAsync(p => p.Name == name);
                        if (!await dbContext.ShoppingCart.AnyAsync(s => s.Name == name))
                        {

                            dbContext.ShoppingCart.Add(new Product()
                            {
                                Name = supplement!.Name,
                                Image = supplement.ImageUrl,
                                Price = supplement.Price,
                                UserId = userGuidId,
                                Quantity = (int)quantity,
                                Size = "",
                                Type = typeOfProduct
                            });
                        }
                        else
                        {
                            var product = await dbContext.ShoppingCart.Where(p => p.Name == name).FirstOrDefaultAsync();
                            product!.Quantity += (int)quantity;
                        }
                        await dbContext.SaveChangesAsync();
                        Task.Delay(1500).Wait();
                    }
                    else if (typeOfProduct == TypeProductAccessory)
                    {
                        accessory = await dbContext.Accessories.FirstOrDefaultAsync(a => a.Name == name);
                        if (!await dbContext.ShoppingCart.AnyAsync(s => s.Name == name))
                        {

                            dbContext.ShoppingCart.Add(new Product()
                            {
                                Name = accessory!.Name,
                                Image = accessory.ImageUrl,
                                Price = accessory.Price,
                                UserId = userGuidId,
                                Quantity = (int)quantity,
                                Size = "",
                                Type = typeOfProduct
                            });
                        }
                        else
                        {
                            var product = await dbContext.ShoppingCart.Where(p => p.Name == name).FirstOrDefaultAsync();
                            product!.Quantity += (int)quantity;
                        }
                        await dbContext.SaveChangesAsync();
                        Task.Delay(1500).Wait();
                    }
                    else if (typeOfProduct == TypeProductWear)
                    {
                        wear = await dbContext.Clothes.FirstOrDefaultAsync(w => w.Name == name);
                        if (!await dbContext.ShoppingCart.AnyAsync(s => s.Name == name && s.Size == size))
                        {

                            dbContext.ShoppingCart.Add(new Product()
                            {
                                Name = wear!.Name,
                                Image = wear.ImageUrl,
                                Price = wear.Price,
                                UserId = userGuidId,
                                Quantity = (int)quantity,
                                Size = size,
                                Type = typeOfProduct
                            });
                        }
                        else
                        {
                            var product = await dbContext.ShoppingCart.Where(p => p.Name == name && p.Size == size).FirstOrDefaultAsync();
                            product!.Quantity += (int)quantity;
                        }
                        await dbContext.SaveChangesAsync();
                        Task.Delay(1500).Wait();
                    }
                }
                else if(!quantity.HasValue)
                {
                    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Guid userGuidId;
                    Guid.TryParse(userId, out userGuidId);

                    Accessory? accessory;
                    Supplement? supplement;
                    Wear? wear;

                    if (typeOfProduct == TypeProductSupplement)
                    {
                        supplement = await dbContext.Supplements.FirstOrDefaultAsync(p => p.Name == name);
                        if (!await dbContext.ShoppingCart.AnyAsync(s => s.Name == name))
                        {

                            dbContext.ShoppingCart.Add(new Product()
                            {
                                Name = supplement!.Name,
                                Image = supplement.ImageUrl,
                                Price = supplement.Price,
                                UserId = userGuidId,
                                Quantity = 1,
                                Size = "",
                                Type = typeOfProduct
                            });
                        }
                        else
                        {
                            var product = await dbContext.ShoppingCart.Where(p => p.Name == name).FirstOrDefaultAsync();
                            product!.Quantity++;
                        }
                        await dbContext.SaveChangesAsync();
                        Task.Delay(1500).Wait();
                    }
                    else if (typeOfProduct == TypeProductAccessory)
                    {
                        accessory = await dbContext.Accessories.FirstOrDefaultAsync(a => a.Name == name);
                        if (!await dbContext.ShoppingCart.AnyAsync(s => s.Name == name))
                        {

                            dbContext.ShoppingCart.Add(new Product()
                            {
                                Name = accessory!.Name,
                                Image = accessory.ImageUrl,
                                Price = accessory.Price,
                                UserId = userGuidId,
                                Quantity = 1,
                                Size = "",
                                Type = typeOfProduct
                            });
                        }
                        else
                        {
                            var product = await dbContext.ShoppingCart.Where(p => p.Name == name).FirstOrDefaultAsync();
                            product!.Quantity++;
                        }
                        await dbContext.SaveChangesAsync();
                        Task.Delay(1500).Wait();
                    }
                    else if (typeOfProduct == TypeProductWear)
                    {
                        wear = await dbContext.Clothes.FirstOrDefaultAsync(w => w.Name == name);
                        if (!await dbContext.ShoppingCart.AnyAsync(s => s.Name == name && s.Size == size))
                        {

                            dbContext.ShoppingCart.Add(new Product()
                            {
                                Name = wear!.Name,
                                Image = wear.ImageUrl,
                                Price = wear.Price,
                                UserId = userGuidId,
                                Quantity = 1,
                                Size = size,
                                Type = typeOfProduct
                            });
                        }
                        else
                        {
                            var product = await dbContext.ShoppingCart.Where(p => p.Name == name && p.Size == size).FirstOrDefaultAsync();
                            product!.Quantity++;
                        }
                        await dbContext.SaveChangesAsync();
                        Task.Delay(1500).Wait();
                    }

                }
            }
            catch
            {
                BadRequest();
            };
            return RedirectToAction("MyCartItems", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var product = await dbContext
                .ShoppingCart
                .FirstOrDefaultAsync(ue => ue.Id == id && ue.UserId.ToString() == userId);

            try
            {
                if (product != null)
                    dbContext.ShoppingCart.Remove(product!);


                await dbContext.SaveChangesAsync();
            }
            catch
            {
                BadRequest();
            }
            return RedirectToAction("MyCartItems", "Cart");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveAllFromCart()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userGuidId;
            Guid.TryParse(userId, out userGuidId);

            var products = await dbContext.ShoppingCart.Select(p => new Product()
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Size = p.Size,
                Price = p.Price,
                Quantity = p.Quantity,
                Type = p.Type,
                User = p.User,
                UserId = userGuidId
            })
                .ToListAsync();
            try
            {
                if (products != null)
                {
                    dbContext.ShoppingCart.RemoveRange(products!);
                }
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                BadRequest();
            }
            return RedirectToAction("MyCartItems", "Cart");
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userGuidId;
            Guid.TryParse(userId, out userGuidId);
            var products = await dbContext.ShoppingCart.Select(p => new Product()
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Size = p.Size,
                Price = p.Price,
                Quantity = p.Quantity,
                Type = p.Type,
                User = p.User,
                UserId = userGuidId
            })
               .ToListAsync();
            if (products.Count == 0)
            { 
                //To set alert for "Your cart is empty!"
                return RedirectToAction("Index","Home");
            }
            OrderViewModel model = new OrderViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Guid userGuidId;
                Guid.TryParse(userId, out userGuidId);

                Order order = new Order()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    Description = model.Description,
                    PhoneNumber = model.PhoneNumber,
                    UserId = userGuidId
                };

                var products = await dbContext.ShoppingCart.Select(p => new Product()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Image = p.Image,
                    Size = p.Size,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Type = p.Type,
                    User = p.User,
                    UserId = userGuidId
                })
                .ToListAsync();

                if (products != null)
                {
                    dbContext.ShoppingCart.RemoveRange(products!);
                }
                await dbContext.Orders.AddAsync(order);
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                BadRequest();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
