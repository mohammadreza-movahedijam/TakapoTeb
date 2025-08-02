using Application.Commands.Question;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Question;

public sealed record GetQuestionQuery:IRequest<QuestionDto>
{
    public Guid Id { get; set; }
}
