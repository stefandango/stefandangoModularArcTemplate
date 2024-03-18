using Ardalis.Result;

using MediatR;

using ModularMonolith.Users.CartEndpoints;

namespace ModularMonolith.Users.UseCases;

public record AddItemToCardCommand(Guid Module1Id, int Value, string EmailAddress) : IRequest<Result>;