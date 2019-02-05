namespace LateRoomsKataCheckout
{
    public interface IDiscount
    {
        char ProductSku { get; set; }
        int Quantity { get; set; }
        int Value { get; set; }
    }
}