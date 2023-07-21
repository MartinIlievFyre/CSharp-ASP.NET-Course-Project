namespace GymApp.Data.Interfaces
{
    public interface ICartItem
    {
        int Id { get; set; }
        int Quantity { get; set; }
        decimal Price { get; }
    }
}
