using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Feedback;

public sealed record GetFeedbackItemQuery:IRequest<IReadOnlyList<FeedbackViewModel>>
{

}
