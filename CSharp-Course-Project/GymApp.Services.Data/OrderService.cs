using GymApp.Data;
using GymApp.Data.Models;
using GymApp.Services.Data.Interfaces;
using GymApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly GymAppDbContext dbContext;
        public OrderService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Order> CreateNewOrderAsync(OrderViewModel model, Guid userGuidId)
        {
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
            if (order == null)
            {
                throw new ArgumentException();
            }
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }
    }
}
