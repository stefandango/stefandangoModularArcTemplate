using Ardalis.GuardClauses;

using Microsoft.AspNetCore.Identity;

namespace ModularMonolith.Users;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    private readonly List<CartItem> _cartItems = new();
    public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();

    public void AddItemToCard(CartItem item)
    {
        Guard.Against.Null(item);
        var existingModule1 = _cartItems.SingleOrDefault(c => c.Module1Id == item.Module1Id);
        if (existingModule1 != null)
        {
            existingModule1.UpdateValue(existingModule1.Value + item.Value);
            return;
        }
        _cartItems.Add(item);
    }
}

public class CartItem
{
    public CartItem(Guid module1Id, string name, int value)
    {
        Module1Id = Guard.Against.Default(module1Id);
        Name = Guard.Against.NullOrEmpty(name);
        Value = Guard.Against.Negative(value);
    }
    public Guid Id { get; private set; }
    public Guid Module1Id { get; private set; }
    public string Name { get; private set; } = String.Empty;
    public int Value { get; private set; }

    internal void UpdateValue(int value)
    {
        Value = Guard.Against.Negative(value);
    }
}