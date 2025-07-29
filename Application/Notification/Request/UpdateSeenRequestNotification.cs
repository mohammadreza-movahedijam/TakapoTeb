using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notification.Request;

public sealed record UpdateSeenRequestNotification:INotification
{
    public bool IsService { get; set; }
    public Guid Id { get; set; }
}
