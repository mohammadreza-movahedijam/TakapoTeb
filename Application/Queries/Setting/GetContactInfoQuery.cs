using Application.Queries.Setting.ViewModels;
using MediatR;

namespace Application.Queries.Setting;

public sealed record GetContactInfoQuery : IRequest<ContactUsViewModel>
{
}
