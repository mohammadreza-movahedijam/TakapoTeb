using Application.Contract;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Feedback;

internal sealed class GetFeedbackItemHandler :
    IRequestHandler<GetFeedbackItemQuery, IReadOnlyList<FeedbackViewModel>>
{
    readonly IRepository<FeedbackEntity> _feedbackRepository;
    public GetFeedbackItemHandler(IRepository<FeedbackEntity> feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }
    public async Task<IReadOnlyList<FeedbackViewModel>> Handle
        (GetFeedbackItemQuery request, CancellationToken cancellationToken)
    {
        IQueryable<FeedbackEntity> query = _feedbackRepository.GetByQuery();
        return await query.
            Select(x => new FeedbackViewModel (){
        
                Id = x.Id,
                ExplanationEn=x.ExplanationEn,
                ExplanationFa=x.ExplanationFa,
                FullNameEn=x.FullNameEn,
                FullNameFa=x.FullNameFa,
                JobPositionEn=x.JobPositionEn,  
                JobPositionFa=x.JobPositionFa,
        }).ToListAsync();

    }
}
