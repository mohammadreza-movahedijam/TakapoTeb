using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.TreatmentCenter;

public sealed record DeleteTreatmentCenterCommand:IRequest
{
    public Guid Id { get; set; }

}
