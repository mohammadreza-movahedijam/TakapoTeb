using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Departement;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.Question;

internal sealed class GetQuestionsHandler :
    IRequestHandler<GetQuestionsQuery, PaginatedList<QuestionViewModel>>
{
    readonly IRepository<QuestionEntity> _repository;

    public GetQuestionsHandler(IRepository<QuestionEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<QuestionViewModel>>
        Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<QuestionEntity> query = _repository.GetByQuery();

        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w => w.Title!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        PaginatedList<QuestionViewModel> model =
            await query.MappingedAsync<QuestionEntity, QuestionViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total);
        return model;
    }
}
