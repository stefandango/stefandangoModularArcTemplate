using FastEndpoints;

using Microsoft.AspNetCore.Identity;

namespace ModularMonolith.Users.UserEndpoints;

public record CreateUserRequest(string Email, string Password);

internal class Create : Endpoint<CreateUserRequest>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public Create(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser { UserName = request.Email, Email = request.Email };
        await _userManager.CreateAsync(user, request.Password);

        await SendOkAsync();
    }
}