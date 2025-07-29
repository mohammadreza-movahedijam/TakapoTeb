using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Request;

public sealed record GetRequestEducationQuery
    :IRequest<RequestEducationDetailViewModel>
{
    public Guid Id { get; set; }
}
