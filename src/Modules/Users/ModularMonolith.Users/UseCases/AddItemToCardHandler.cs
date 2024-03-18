using Ardalis.Result;

using MediatR;

using ModularMonolith.Module1.Contracts;

namespace ModularMonolith.Users.UseCases;

public class AddItemToCardHandler : IRequestHandler<AddItemToCardCommand, Result>
{
    private readonly IApplicationUserRepository _userRepository;
    private readonly IMediator _mediator;
    public AddItemToCardHandler(IApplicationUserRepository userRepository, IMediator mediator)
    {
        _userRepository = userRepository;
        _mediator = mediator;
    }
    public async Task<Result> Handle(AddItemToCardCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserWithCartByEmailAsync(request.EmailAddress);

        if (user is null)
        {
            return Result.Unauthorized();
        }


        var query = new Module1DetailsQuery(request.Module1Id);
        var result = await _mediator.Send(query);
        if (result.Status == ResultStatus.NotFound)
        {
            return Result.NotFound();
        }

        var module1Details = result.Value;

        var newCartItem = new CartItem(request.Module1Id, module1Details.Name, request.Value);
        
        user.AddItemToCard(newCartItem);

        await _userRepository.SaveChangesAsync();
        return Result.Success();

    }
}