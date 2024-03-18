using Ardalis.Result;

using MediatR;

using ModularMonolith.Module1.Contracts;

namespace ModularMonolith.Module1.Integrations;

internal class Module1DetailsQueryHandler : IRequestHandler<Module1DetailsQuery, Result<Module1DetailsResponse>>
{
    private readonly IModule1Service _module1Service;
    public Module1DetailsQueryHandler(IModule1Service module1Service)
    {
        _module1Service = module1Service;
    }
    public async Task<Result<Module1DetailsResponse>> Handle(Module1DetailsQuery request, CancellationToken cancellationToken)
    {
        var module1 = await _module1Service.GetModule1ItemAsync(request.Module1Id);
        if (module1 is null)
        {
            return Result.NotFound();
        }

        var response = new Module1DetailsResponse(module1.Id, module1.Name, module1.Value);
        return response;
    }
}