using Application.Commands.Role.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Role;

public sealed record GetRoleRoutesQuery
    :IRequest<ValueTuple<IReadOnlyList<RouteDto>, IReadOnlyList<Guid>>>
{
    public Guid RoleId { get; set; }
}
