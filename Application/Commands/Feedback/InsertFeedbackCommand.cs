using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Feedback;

public sealed record InsertFeedbackCommand:IRequest
{
    public FeedbackDto Feedback { get; set; }
}
