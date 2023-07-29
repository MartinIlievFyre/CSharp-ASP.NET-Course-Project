namespace GymApp.ViewModels.Cart
{
    using System.ComponentModel.DataAnnotations;
    using static GymApp.Common.EntityValidationConstants.CartFormViewModel;
    public class CartFormViewModel
    {
        public CartFormViewModel()
        {
            AccesspryItems = new HashSet<CartItemViewModel>();
            TotalPrice = 0;
        }
        public string Id { get; set; } = null!;

        [Range(typeof(decimal), TotalPriceMinValue, TotalPriceMaxValue)]
        public decimal TotalPrice { get; set; }

        public IEnumerable<CartItemViewModel> AccesspryItems { get; set; }
    }
}
