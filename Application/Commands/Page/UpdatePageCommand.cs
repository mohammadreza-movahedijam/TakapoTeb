using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Page;

public sealed record UpdatePageCommand:IRequest
{
    public PageDto? Page { get; set; }
}
