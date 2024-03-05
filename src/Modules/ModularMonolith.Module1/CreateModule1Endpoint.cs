using FastEndpoints;

namespace ModularMonolith.Module1;

internal class CreateModule1Endpoint(IModule1Service service) : Endpoint<CreateModule1Request, Module1Dto>
{
    public override void Configure()
    {
        Post("/module1");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CreateModule1Request request, CancellationToken cancellationToken = default)
    {
        var newObject1 = new Module1Dto(request.Id ?? Guid.NewGuid(), request.Name, request.Value);
        await service.CreateModule1ItemAsync(newObject1);
        await SendCreatedAtAsync<GetModule1ByIdEndpoint>(new {newObject1.Id}, newObject1, cancellation: cancellationToken);
    }
}
