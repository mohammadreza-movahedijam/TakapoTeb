using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Commands.Question;

internal sealed class DeleteQuestionHandler :
    IRequestHandler<DeleteQuestionCommand>
{
    readonly IRepository<QuestionEntity> _questionRepository;
    public DeleteQuestionHandler(IRepository<QuestionEntity> questionRepository)
    {
        _questionRepository = questionRepository;
    }
    public async Task Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        QuestionEntity? question = await _questionRepository
            .GetAsync(g => g.Id == request!.Id, cancellationToken);

        if (question is null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        question.IsDeleted = true;
        await _questionRepository.UpdateAsync(question, cancellationToken);
    }
}
