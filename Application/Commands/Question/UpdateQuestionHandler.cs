using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;

namespace Application.Commands.Question;

internal sealed class UpdateQuestionHandler :
    IRequestHandler<UpdateQuestionCommand>
{
    readonly IRepository<QuestionEntity> _questionRepository;
    public UpdateQuestionHandler(IRepository<QuestionEntity> questionRepository)
    {
        _questionRepository = questionRepository;
    }
    public async Task Handle(UpdateQuestionCommand request,
        CancellationToken cancellationToken)
    {
        QuestionEntity? question = await _questionRepository
            .GetAsync(g => g.Id == request.Question!.Id, cancellationToken);

        if (question is null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        request.Question.Adapt(question);
        await _questionRepository.UpdateAsync(question, cancellationToken);
    }
}
