using Application.Commands.Feature;
using Application.Commands.Feedback;
using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Feedback;

public sealed record GetFeedbackQuery:IRequest<FeedbackDto>
{
    public Guid Id { get; set; }    
}
