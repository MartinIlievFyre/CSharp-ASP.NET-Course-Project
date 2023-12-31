﻿namespace GymApp.ViewModels.Clothing
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using GymApp.ViewModels.WearCategory;

    using static GymApp.Common.EntityValidationConstants.Wear;

    public class EditWearViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
        [Required]
        [Range((typeof(Decimal)), PriceMin, PriceMax)]
        public decimal Price { get; set; }
        [Required]
        [MaxLength(ImageUrlMaxlLength)]
        public string ImageUrl { get; set; } = null!;
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;
        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        public string Color { get; set; } = null!;
        [Required]
        [StringLength(SizeMaxLength, MinimumLength = SizeMinLength)]
        public string Size { get; set; } = null!;
        [Required]
        [StringLength(FabricMaxLength, MinimumLength = FabricMinLength)]
        public string Fabric { get; set; } = null!;
        public int CategoryId { get; set; }
        public ICollection<WearCategoryViewModel> WearCategories { get; set; } = new List<WearCategoryViewModel>();
    }
}
