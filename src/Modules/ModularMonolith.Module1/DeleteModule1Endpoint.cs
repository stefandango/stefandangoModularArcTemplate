using FastEndpoints;

namespace ModularMonolith.Module1;

internal class DeleteModule1Endpoint(IModule1Service service) : Endpoint<DeleteModule1Request>
{
    public readonly IModule1Service _moduleService = service;
    public override void Configure()
    {
        Delete("/module1/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(DeleteModule1Request request, CancellationToken cancellationToken = default)
    {
        await _moduleService.DeleteModule1ItemAsync(request.Id);
        await SendNoContentAsync();
    }
}