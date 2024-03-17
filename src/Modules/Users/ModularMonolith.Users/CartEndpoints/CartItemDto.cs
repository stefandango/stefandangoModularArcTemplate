namespace ModularMonolith.Users.CartEndpoints;

public record CartItemDto(Guid Id, Guid Module1Id, string Name, int Value);