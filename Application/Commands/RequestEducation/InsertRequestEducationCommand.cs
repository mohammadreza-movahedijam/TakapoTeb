using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.RequestEducation;

public sealed record InsertRequestEducationCommand:IRequest
{
    public RequestEducationDto? RequestEducation { get; set; }
}
