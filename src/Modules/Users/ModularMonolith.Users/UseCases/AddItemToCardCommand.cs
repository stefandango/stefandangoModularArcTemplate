using Ardalis.Result;

using MediatR;

using ModularMonolith.Users.CartEndpoints;

namespace ModularMonolith.Users.UseCases;

public record AddItemToCardCommand(Guid Module1Id, int Value, string EmailAddress) : IRequest<Result>;

public class AddItemToCardHandler : IRequestHandler<AddItemToCardCommand, Result>
{
    public Task<Result> Handle(AddItemToCardCommand request, CancellationToken cancellationToken)
    {
        throw new Exception();
    }
}