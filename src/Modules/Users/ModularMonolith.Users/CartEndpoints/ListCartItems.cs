using System.Security.Claims;

using Ardalis.Result;

using FastEndpoints;

using MediatR;

using ModularMonolith.Users.UseCases;

namespace ModularMonolith.Users.CartEndpoints;

internal class ListCartItems(IMediator mediator) : EndpointWithoutRequest<CartResponse>
{
    private readonly IMediator _mediator = mediator;

    public override void Configure()
    {
        Get("/cart");
        Claims("EmailAddress");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var emailAddress = User.FindFirstValue("EmailAddress");
        var query = new ListCartItemsQuery(emailAddress!);

        var result = await _mediator.Send(query, ct);

        if (result.Status == ResultStatus.Unauthorized)
        {
            await SendUnauthorizedAsync(ct);
        }
        else
        {
            var response = new CartResponse() { CartItems = result.Value };
            await SendAsync(response, cancellation: ct);
        }
    }
}