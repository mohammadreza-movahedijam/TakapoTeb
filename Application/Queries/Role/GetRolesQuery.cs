using Application.Common;
using Application.Contract;
using Application.Queries.Role.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Role;

public sealed record GetRolesQuery:IRequest<PaginatedList<RoleViewModel>>
{
    public IPagination Pagination { get; set; }
    public GetRolesQuery(IPagination Pagination)
    {
        this.Pagination= Pagination;
    }
}
