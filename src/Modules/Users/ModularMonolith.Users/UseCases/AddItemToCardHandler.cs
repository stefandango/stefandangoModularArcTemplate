using Ardalis.Result;

using MediatR;

namespace ModularMonolith.Users.UseCases;

public class AddItemToCardHandler : IRequestHandler<AddItemToCardCommand, Result>
{
    private readonly IApplicationUserRepository _userRepository;
    public AddItemToCardHandler(IApplicationUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result> Handle(AddItemToCardCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserWithCartByEmailAsync(request.EmailAddress);

        if (user is null)
        {
            return Result.Unauthorized();
        }

        var newCartItem = new CartItem(request.Module1Id, request.Name, request.Value);
        
        user.AddItemToCard(newCartItem);

        await _userRepository.SaveChangesAsync();
        return Result.Success();

    }
}