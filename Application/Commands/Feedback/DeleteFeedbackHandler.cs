using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Feedback;

internal sealed class DeleteFeedbackHandler :
    IRequestHandler<DeleteFeedbackCommand>
{
    readonly IRepository<FeedbackEntity> _repository;
    public DeleteFeedbackHandler(IRepository<FeedbackEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
    {
        FeedbackEntity? feedback = await _repository
           .GetAsync(g => g.Id == request.Id, cancellationToken);
        feedback!.IsDeleted=true; 
        await _repository.UpdateAsync(feedback, cancellationToken);
    }
}
