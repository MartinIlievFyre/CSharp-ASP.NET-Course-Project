﻿namespace GymApp.Models
{
    public class CartViewModel
    {
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        public decimal FinalPrice { get; set; }
    }
}
