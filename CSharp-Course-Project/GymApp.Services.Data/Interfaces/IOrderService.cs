namespace GymApp.Services.Data.Interfaces
{
    using GymApp.ViewModels;
    using GymApp.Data.Models;

    public interface IOrderService
    {
        Task<Order> CreateNewOrderAsync(OrderViewModel model, Guid userGuidId);
    }
}
