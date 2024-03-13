using Microsoft.AspNetCore.Identity;
using FastEndpoints;
using FastEndpoints.Security;

namespace ModularMonolith.Users.UserEndpoints;

public record UserLoginRequest(string Email, string Password);
public class Login : Endpoint<UserLoginRequest>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public Login(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("/users/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserLoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            await SendUnauthorizedAsync(cancellationToken);
            return;
        }

        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!result)
        {
            await SendUnauthorizedAsync(cancellationToken);
            return;
        }

        var jwtSecret = Config["Auth:JwtSecret"];
        //var token = JWTBearer.CreateToken(jwtSecret!, p => p["EmailAddress"] = user.Email!);
        var token = JwtBearer.CreateToken(o =>
        {
            o.SigningKey = jwtSecret!;
            o.User.Claims.Add(("EmailAddress", user.Email!));
        });
        await SendAsync(token, cancellation: cancellationToken);
    }
}
