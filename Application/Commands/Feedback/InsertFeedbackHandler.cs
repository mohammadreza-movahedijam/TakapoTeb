using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;

namespace Application.Commands.Feedback;

internal sealed class InsertFeedbackHandler :
    IRequestHandler<InsertFeedbackCommand>
{
    readonly IRepository<FeedbackEntity> _feedbackRepository;
    public InsertFeedbackHandler(IRepository<FeedbackEntity> feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }
    public async Task Handle(InsertFeedbackCommand request, CancellationToken cancellationToken)
    {
        FeedbackEntity feedbackEntity = request.Feedback.Adapt<FeedbackEntity>();
        await _feedbackRepository.InsertAsync(feedbackEntity,cancellationToken);
    }
}
