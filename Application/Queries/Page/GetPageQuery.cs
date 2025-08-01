using Application.Commands.Page;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Page;

public class GetPageQuery:IRequest<PageDto>
{
    public Guid Id { get; set; }
}
