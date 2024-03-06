using FastEndpoints;

namespace ModularMonolith.Module1;

public class UpdateValueRequest
{
    public Guid Id {get; set;}
    public int Value {get;set;}
}

internal class UpdateValueEndpoint(IModule1Service service) : Endpoint<UpdateValueRequest>
{
    private readonly IModule1Service _moduleService = service;
    public override void Configure()
    {Q
        Post("/module1/{id}/valuehistory");
        AllowAnonymous();
    }
    public override async Task HandleAsync(UpdateValueRequest request, CancellationToken cancellationToken = default)
    {
        await _moduleService.UpdateModule1ItemValueAsync(request.Id, request.Value);
        var updatedModule1 = await _moduleService.GetModule1ItemAsync(request.Id);
        await SendAsync(updatedModule1);
    }
}
