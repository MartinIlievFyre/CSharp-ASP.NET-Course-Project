namespace GymApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static GymApp.Common.EntityValidationConstants.Order;

    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();

            CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }

        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; }

        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; }

        [MaxLength(CountryNameMaxLength)]
        public string? Country { get; set; }

        [MaxLength(CityNameMaxLength)]
        public string? City { get; set; }

        [MaxLength(AddressMaxLength)]
        public string? Address { get; set; }

        [MaxLength(PostCodeMaxLength)]
        public string? PostCode { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }

        [Required]
        public Cart Cart { get; set; } = null!;

        public decimal TotalPrice { get; set; }
    }
}
