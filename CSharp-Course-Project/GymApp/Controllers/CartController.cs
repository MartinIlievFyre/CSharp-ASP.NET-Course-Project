namespace GymApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using GymApp.ViewModels;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;
    using GymApp.Infrastructure.Extensions;

    using static GymApp.Common.GeneralApplicationConstants;
    using static GymApp.Common.NotificationMessagesConstants;

    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly ISupplementService supplementService;
        private readonly IAccessoryService accessoryService;
        private readonly IWearService wearService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        public CartController( ICartService cartService, ISupplementService supplementService, IAccessoryService accessoryService, IWearService wearService, IProductService productService, IOrderService orderService )
        {
            this.cartService = cartService;
            this.supplementService = supplementService;
            this.accessoryService = accessoryService;
            this.wearService = wearService;
            this.productService = productService;
            this.orderService = orderService;
        }
       
        [HttpGet]
        public async Task<IActionResult> MyCartItems()
        {
            try
            {
                string? userId = User.GetId();

                List<Product> products = await productService.GetAllProductsInCartByUserIdAsync(userId);

                List<ProductViewModel> modelProducts = productService.GetAllProductViewModelsOnProducts(products);

                decimal sum = cartService.GetTotalSumOfAllProducts(modelProducts);

                CartViewModel model = cartService.CreateNewCartViewModel(modelProducts, sum);
                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string name, string typeOfProduct, string size, int? quantity)
        {
            try
            {

                if (quantity.HasValue && quantity > 0)
                {
                    string? userId = User.GetId();
                    Guid userGuidId;
                    Guid.TryParse(userId, out userGuidId);

                    Accessory? accessory;
                    Supplement? supplement;
                    Wear? wear;

                    if (typeOfProduct == TypeProductSupplement)
                    {
                        supplement = await supplementService.GetSupplemenntByNameAsync(name);
                        if (!await cartService.IsInCartHasProductByNameAsync(name))
                        {
                            await cartService.AddSupplementToCartAsync(supplement, userGuidId, typeOfProduct, quantity);
                        }
                        else
                        {
                            Product? product = await productService.GetProductFromShoppingCartByNameAsync(name);
                            await cartService.IncreaseProductQuantityWithOne(product, quantity);
                        }
                    }
                    else if (typeOfProduct == TypeProductAccessory)
                    {
                        accessory = await accessoryService.GetAccessoryByNameAsync(name);
                        if (!await cartService.IsInCartHasProductByNameAsync(name))
                        {
                            await cartService.AddAccessoryToCartAsync(accessory, userGuidId, typeOfProduct, quantity);
                        }
                        else
                        {
                            Product? product = await productService.GetProductFromShoppingCartByNameAsync(name);
                            await cartService.IncreaseProductQuantityWithOne(product, quantity);
                        }
                    }
                    else if (typeOfProduct == TypeProductWear)
                    {
                        wear = await wearService.GetWearByNameAsync(name);
                        if (!await cartService.IsInCartHasProductByNameAndSizeAsync(name, size))
                        {
                            await cartService.AddWearToCartAsync(wear, userGuidId, typeOfProduct, size, quantity);
                        }
                        else
                        {
                            Product? product = await productService.GetProductFromShoppingCartByNameAndSizeAsync(name, size);
                            await cartService.IncreaseProductQuantityWithOne(product, quantity);
                        }
                    }
                }
                else if (!quantity.HasValue)
                {
                    string? userId = User.GetId();
                    Guid userGuidId;
                    Guid.TryParse(userId, out userGuidId);

                    Accessory? accessory;
                    Supplement? supplement;
                    Wear? wear;

                    quantity = 1;

                    if (typeOfProduct == TypeProductSupplement)
                    {
                        supplement = await supplementService.GetSupplemenntByNameAsync(name);
                        if (!await cartService.IsInCartHasProductByNameAsync(name))
                        {
                            await cartService.AddSupplementToCartAsync(supplement, userGuidId, typeOfProduct, quantity);
                        }
                        else
                        {
                            Product? product = await productService.GetProductFromShoppingCartByNameAsync(name);
                            await cartService.IncreaseProductQuantityWithOne(product, quantity);
                        }
                    }
                    else if (typeOfProduct == TypeProductAccessory)
                    {
                        accessory = await accessoryService.GetAccessoryByNameAsync(name);
                        if (!await cartService.IsInCartHasProductByNameAsync(name))
                        {
                            await cartService.AddAccessoryToCartAsync(accessory, userGuidId, typeOfProduct, quantity);
                        }
                        else
                        {
                            Product? product = await productService.GetProductFromShoppingCartByNameAsync(name);
                            await cartService.IncreaseProductQuantityWithOne(product, quantity);
                        }
                    }
                    else if (typeOfProduct == TypeProductWear)
                    {
                        wear = await wearService.GetWearByNameAsync(name);
                        if (!await cartService.IsInCartHasProductByNameAndSizeAsync(name, size))
                        {
                            await cartService.AddWearToCartAsync(wear, userGuidId, typeOfProduct, size, quantity);
                        }
                        else
                        {
                            Product? product = await productService.GetProductFromShoppingCartByNameAndSizeAsync(name, size);
                            await cartService.IncreaseProductQuantityWithOne(product, quantity);
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            };

            TempData["Success"] = SuccessfullyAddedProductToCart;
            return RedirectToAction("MyCartItems", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            try
            {
                string? userId = User.GetId();

                var product = await productService.GetProductFromShoppingCartByProductIdAndUserIdAsync(id, userId);

                if (product != null)
                {
                    await cartService.RemoveProductFromCartAsync(product!);
                }
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
            TempData["Error"] = SuccessfullyRemovedProductFormCart;
            return RedirectToAction("MyCartItems", "Cart");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAllFromCart()
        {
            try
            {
                string? userId = User.GetId();
                Guid userGuidId;
                Guid.TryParse(userId, out userGuidId);

                List<Product>? products = await productService.GetAllProductsInCartAsync(userGuidId);

                if (products != null)
                {
                    await cartService.RemoveAllProductsFromCartAsync(products);
                }
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = SuccessfullyRemovedAllProductsFromCart;
            return RedirectToAction("MyCartItems", "Cart");
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            try
            {
                string? userId = User.GetId();
                Guid userGuidId;
                Guid.TryParse(userId, out userGuidId);

                List<Product>? products = await productService.GetAllProductsInCartAsync(userGuidId);

                if (products.Count == 0)
                {
                    TempData["Error"] = ThereAreNoProductsInCart;
                    return RedirectToAction("Index", "Home");
                }
                OrderViewModel model = new OrderViewModel();
                return View(model);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message; ;
                return RedirectToAction("Index", "Home");
            }
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

                string? userId = User.GetId();
                Guid userGuidId;
                Guid.TryParse(userId, out userGuidId);

                List<Product>? products = await productService.GetAllProductsInCartAsync(userGuidId);

                Order order = await orderService.CreateNewOrderAsync(model, userGuidId);

                if (products != null)
                {
                    await cartService.RemoveAllProductsFromCartAsync(products);
                }
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

            TempData["Success"] = SuccessfullyPlacedOrder;
            return RedirectToAction("Index", "Home");
        }
    }
}
