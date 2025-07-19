using Application.Commands.Role.DataTransferObject;
using Application.Contract;
using Domain.Entities.Identity;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Role;

internal sealed class GetRoleRoutesHandler :
    IRequestHandler<GetRoleRoutesQuery, ValueTuple<IReadOnlyList<RouteDto>, IReadOnlyList<Guid>>>
{
    readonly IRepository<RoleRouteEntity> _mapRepository;
    readonly IRepository<RouteEntity> _routeRepository;
    public GetRoleRoutesHandler(IRepository<RouteEntity> routeRepository
        , IRepository<RoleRouteEntity> mapRepository)
    {
        _mapRepository = mapRepository;
        _routeRepository = routeRepository;
    }
    public async Task<ValueTuple<IReadOnlyList<RouteDto>, IReadOnlyList<Guid>>>
        Handle(GetRoleRoutesQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<RouteEntity> query = _routeRepository.GetByQuery();
        var routes=await query.ToListAsync();
        var routeDtos = routes.Adapt<List<RouteDto>>();
        IQueryable< RoleRouteEntity> mapQuery=_mapRepository.GetByQuery();
        var selectedRoute=await mapQuery.Where(w=>w.RoleId==request.RoleId)
            .Select(s=>s.RouteId).ToListAsync();
        return ValueTuple.Create(routeDtos, selectedRoute);
    }
}
