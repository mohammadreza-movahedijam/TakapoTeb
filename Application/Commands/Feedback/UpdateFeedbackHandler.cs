using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Feedback;

internal sealed class UpdateFeedbackHandler :
    IRequestHandler<UpdateFeedbackCommand>
{
    readonly IRepository<FeedbackEntity> _repository;
    public UpdateFeedbackHandler(IRepository<FeedbackEntity> repository)
    {
        _repository = repository;   
    }
    public async Task Handle(UpdateFeedbackCommand request, 
        CancellationToken cancellationToken)
    {
        FeedbackEntity? feedback = await _repository
            .GetAsync(g => g.Id == request.Feedback.Id, cancellationToken);
        request.Feedback.Adapt(feedback);
        await _repository.UpdateAsync(feedback!, cancellationToken);
    }
}
