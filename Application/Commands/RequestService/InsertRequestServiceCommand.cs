using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.RequestService;

public sealed record InsertRequestServiceCommand:IRequest
{
    public RequestServiceDto? RequestService {  get; set; }
}
