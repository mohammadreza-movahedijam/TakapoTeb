using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Chat;

public sealed record GetGroupQuery:IRequest<ChatGroupViewModel>
{
    public string? ConnectionId {  get; set; }
}
