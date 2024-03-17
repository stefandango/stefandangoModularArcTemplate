namespace ModularMonolith.Users.CartEndpoints;

public class CartResponse
{
    public List<CartItemDto> CartItems { get; set; } = new();
}