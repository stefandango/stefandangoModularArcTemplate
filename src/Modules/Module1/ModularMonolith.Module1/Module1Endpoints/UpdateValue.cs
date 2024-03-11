using FastEndpoints;

using FluentValidation;

namespace ModularMonolith.Module1.Endpoints;

public class UpdateValueRequest
{
    public Guid Id {get; set;}
    public int Value {get;set;}
}

public class UpdateValueRequestValidator : Validator<UpdateValueRequest>
{
    public UpdateValueRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEqual(Guid.Empty)
            .WithMessage("A Valid module is required");

        RuleFor(x => x.Value)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Value cannot be a negative value");
    }
}

internal class UpdateValue(IModule1Service service) : Endpoint<UpdateValueRequest>
{
    private readonly IModule1Service _moduleService = service;
    public override void Configure()
    {
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
