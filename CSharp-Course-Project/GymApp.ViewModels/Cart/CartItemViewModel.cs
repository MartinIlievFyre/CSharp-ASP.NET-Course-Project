﻿namespace GymApp.ViewModels.Cart
{

    using System.ComponentModel.DataAnnotations;
    using static GymApp.Common.EntityValidationConstants.CartItemViewModel;

    public class CartItemViewModel
    {
        public CartItemViewModel()
        {
            Quantity = 0;
            TotalPrice = Price * Quantity;
        }
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string Name { get; set; } = null!;

        public string? Image { get; set; }

        public decimal Price { get; set; }

        [Range(typeof(int), QuantityMinValue, QuantityMaxValue)]
        public int Quantity { get; set; }

        [Range(typeof(decimal), TotalPriceMinValue, TotalPriceMaxValue)]
        public decimal TotalPrice { get; set; }
    }
}