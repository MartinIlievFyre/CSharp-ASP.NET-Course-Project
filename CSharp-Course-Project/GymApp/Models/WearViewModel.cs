﻿using GymApp.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Models
{
    public class WearViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string Size { get; set; } = null!;

        public string WearCategory { get; set; } = null!;

        public ApplicationUserWear Wear { get; set; } = null!;
    }
}
