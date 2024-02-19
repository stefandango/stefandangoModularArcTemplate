using FastEndpoints;

namespace ModularMonolith.Module1;

internal class ListModule1ItemsEndpoint(IModule1Service service) : EndpointWithoutRequest<ListModule1Response>
{
    public readonly IModule1Service _moduleService = service;

    public override void Configure()
    {
        Get("/module1");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken = default)
    {
        var items = _moduleService.ListModule1Items();

        await SendAsync(new ListModule1Response()
        {
            Items = items
        });
    }
}