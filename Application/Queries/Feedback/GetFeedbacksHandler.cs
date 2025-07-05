using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;

namespace Application.Queries.Feedback;

internal sealed class GetFeedbacksHandler :
    IRequestHandler<GetFeedbacksQuery, PaginatedList<FeedbackViewModel>>
{
    readonly IRepository<FeedbackEntity> _repository;
    public GetFeedbacksHandler(IRepository<FeedbackEntity> repository)
    {
        _repository = repository;
    }


    public async Task<PaginatedList<FeedbackViewModel>>
        Handle(GetFeedbacksQuery request, CancellationToken cancellationToken)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<FeedbackEntity, FeedbackViewModel>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.FullNameEn, s => s.FullNameEn)
            .Map(d => d.FullNameFa, s => s.FullNameFa)
            .Map(d => d.JobPositionEn, s => s.JobPositionEn)
            .Map(d => d.JobPositionFa, s => s.JobPositionFa)
            .Compile();
        IQueryable<FeedbackEntity> query = _repository.GetByQuery();

        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.FullNameFa!.Contains(request!.Pagination!.keyword)
            || w.FullNameFa!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        PaginatedList<FeedbackViewModel> model =
            await query.MappingedAsync<FeedbackEntity, FeedbackViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total, config);
        return model;
    }
}
