using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Departement;

public sealed record UpdateDepartementCommand:IRequest
{
    public DepartementDto? Departement { get; set; }
}
