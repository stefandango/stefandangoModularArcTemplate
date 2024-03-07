using FastEndpoints;

namespace ModularMonolith.Module1.Endpoints;

internal class List(IModule1Service service) : EndpointWithoutRequest<ListModule1Response>
{
    public readonly IModule1Service _moduleService = service;

    public override void Configure()
    {
        Get("/module1");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var items = await _moduleService.ListModule1ItemsAsync();

        await SendAsync(new ListModule1Response()
        {
            Items = items
        });
    }
}