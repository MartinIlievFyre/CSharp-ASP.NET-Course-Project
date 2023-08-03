namespace GymApp.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static GymApp.Common.EntityValidationConstants.Order;
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [StringLength(DescriptionMaxLength, MinimumLength =DescriptionMinLength)]
        public string? Description { get; set; }

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(PhoneLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(CityNameMaxLength, MinimumLength =CityNameMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(CountryNameMaxLength, MinimumLength = CountryNameMinLength)]
        public string Country { get; set; } = null!;

        public Guid UserId { get; set; }

    }
}
