using FastEndpoints;

namespace ModularMonolith.Module1;

internal class GetModule1ByIdEndpoint(IModule1Service service) : Endpoint<GetModule1ByIdRequest, Module1Dto>
{
    public readonly IModule1Service _moduleService = service;
    public override void Configure()
    {
        Get("/module1/{Id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(GetModule1ByIdRequest request, CancellationToken cancellationToken = default)
    {
        var item = await _moduleService.GetModule1ItemAsync(request.Id);
        if (item == null)
        {
            await SendNotFoundAsync();
            return;
        }

        await SendAsync(item);
    }
}