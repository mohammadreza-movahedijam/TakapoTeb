using Application.Commands.Question;
using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.Question;

internal sealed class GetQuestionHandler :
    IRequestHandler<GetQuestionQuery, QuestionDto>
{
    readonly IRepository<QuestionEntity> _questionRepository;
    public GetQuestionHandler(IRepository<QuestionEntity> questionRepository)
    {
        _questionRepository = questionRepository;
    }
    public async Task<QuestionDto> Handle(GetQuestionQuery request,
        CancellationToken cancellationToken)
    {
        QuestionDto question=await _questionRepository
            .GetAsync<QuestionDto>(g=>g.Id==request.Id,null,cancellationToken);
        if (question == null) 
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return question;
    }
}
