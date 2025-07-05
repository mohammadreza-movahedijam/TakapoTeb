using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.News;

public sealed record UpdateNewsCommand:IRequest
{
    public NewsDto News { get; set; }   
}
