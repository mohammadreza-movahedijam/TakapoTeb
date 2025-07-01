using Application.Commands.Departement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Departement;

public sealed record GetDepartementQuery:
    IRequest<DepartementDto>
{
    public Guid Id { get; set; }
}
