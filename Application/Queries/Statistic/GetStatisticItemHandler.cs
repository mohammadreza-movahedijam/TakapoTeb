using Application.Commands.Statistic;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Statistic;

internal sealed class GetStatisticItemHandler :
    IRequestHandler<GetStatisticItemQuery, StatisticViewModel>
{
    readonly IRepository<StatisticEntity> _repository;
    public GetStatisticItemHandler(IRepository<StatisticEntity> repository)
    {
        _repository = repository;
    }
    public async Task<StatisticViewModel> Handle(GetStatisticItemQuery request, CancellationToken cancellationToken)
    {
        IQueryable<StatisticEntity> query = _repository.GetByQuery();
        StatisticEntity? statisticEntity =
            await query.FirstOrDefaultAsync(cancellationToken);
        return statisticEntity.Adapt<StatisticViewModel>();
    }
}
