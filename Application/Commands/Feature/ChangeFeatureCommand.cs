using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Feature;

public sealed record ChangeFeatureCommand:IRequest
{
    public FeatureDto Feature { get; set; }
}
