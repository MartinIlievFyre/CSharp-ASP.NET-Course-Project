﻿namespace GymApp.Models
{
    public class ClothingDetailsViewModel
    {
        public WearViewModel CurrentClothing { get; set; } = null!;
        public List<WearViewModel> RandomClothes { get; set; } = null!;
    }
}
