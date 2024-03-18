using Ardalis.Result;

using MediatR;

namespace ModularMonolith.Module1.Contracts;

public record Module1DetailsQuery(Guid Module1Id) : IRequest<Result<Module1DetailsResponse>>;