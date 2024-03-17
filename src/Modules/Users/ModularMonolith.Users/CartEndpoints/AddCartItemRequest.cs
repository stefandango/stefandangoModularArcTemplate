namespace ModularMonolith.Users.CartEndpoints;

public record AddCartItemRequest(Guid Module1Id,string Name, int Value);