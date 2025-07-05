using Application.Commands.Feedback;
using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.Feedback;

internal sealed class GetFeedbackHandler : IRequestHandler<GetFeedbackQuery, FeedbackDto>
{
    readonly IRepository<FeedbackEntity> _repository;
    public GetFeedbackHandler(IRepository<FeedbackEntity> repository)
    {
        _repository = repository;
    }
    public async Task<FeedbackDto> Handle(GetFeedbackQuery request, CancellationToken cancellationToken)
    {
        FeedbackDto feedback=await _repository
            .GetAsync<FeedbackDto>(g=>g.Id == request.Id,null,cancellationToken);
        if(feedback is null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }

        return feedback;
    }
}
