using Application.Common.Extension;
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

        if (request.Feedback!.File is not null)
        {
            feedback.FilePath = request.Feedback.File.UploadImage("Feedback");
            request.Feedback.FilePath!.RemoveImage("Feedback");
        }
        await _repository.UpdateAsync(feedback!, cancellationToken);
    }
}
