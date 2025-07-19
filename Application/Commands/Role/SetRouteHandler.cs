using Application.Contract;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Role;

internal sealed class SetRouteHandler :
    IRequestHandler<SetRouteCommand>
{

    readonly IRepository<RoleRouteEntity> _repository;
    public SetRouteHandler(IRepository<RoleRouteEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(SetRouteCommand request,
        CancellationToken cancellationToken)
    {
        if (request.RoleRoute.Routes != null && request.RoleRoute.Routes.Any())
        {
            var query = _repository.GetByQuery();
            await query.Where(w => w.RoleId == request.RoleRoute.RoleId).
                 ExecuteDeleteAsync(cancellationToken);
            List<RoleRouteEntity> roleRoutes = [];
            foreach (var route in request.RoleRoute.Routes) 
            {
                RoleRouteEntity entity = new()
                {
                    RoleId = request.RoleRoute.RoleId,
                    RouteId = route
                };
                roleRoutes.Add(entity);
            }
            await _repository.InsertAsync(roleRoutes,cancellationToken);
        }



    }
}
