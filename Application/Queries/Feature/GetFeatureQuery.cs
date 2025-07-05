using Application.Commands.Feature;
using MediatR;

namespace Application.Queries.Feature;

public sealed record GetFeatureQuery : IRequest<FeatureDto>
{
}
