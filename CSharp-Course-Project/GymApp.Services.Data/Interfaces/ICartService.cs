using GymApp.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Services.Data.Interfaces
{
    public interface ICartService
    {
        Task<CartFormViewModel?> GetCartByUserIdAsync(string userId);

        Task CreateCartAsync(string userId);

        Task AddItemToCartAsync(int itemId, string cartId, string userId);

        Task RemoveItemFromCartAsync(int cartItemId);

        Task DecreaseItemCountAsync(int itemId);

        Task IncreaseItemCountAsync(int itemId);
    }
}
