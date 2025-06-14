using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Chat;

public sealed record JoinChatGroupCommand:IRequest<string>
{
    public ChatGroupDto? ChatGroup { get; set; }
}
