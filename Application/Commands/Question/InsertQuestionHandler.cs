using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;

namespace Application.Commands.Question;

internal sealed class InsertQuestionHandler :
    IRequestHandler<InsertQuestionCommand>
{
    readonly IRepository<QuestionEntity> _questionRepository;
    public InsertQuestionHandler(IRepository<QuestionEntity> questionRepository)
    {
        _questionRepository = questionRepository;
    }
    public async Task Handle(InsertQuestionCommand request,
        CancellationToken cancellationToken)
    {
        QuestionEntity question =
            request.Question.Adapt<QuestionEntity>();
        await _questionRepository.UpdateAsync(question, cancellationToken);
    }
}
