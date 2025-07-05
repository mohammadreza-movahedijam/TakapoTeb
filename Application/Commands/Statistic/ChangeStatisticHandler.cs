using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Statistic;

internal sealed class ChangeStatisticHandler :
    IRequestHandler<ChangeStatisticCommand>
{
    readonly IRepository<StatisticEntity> _repository;
    public ChangeStatisticHandler(IRepository<StatisticEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(ChangeStatisticCommand request,
        CancellationToken cancellationToken)
    {
        IQueryable<StatisticEntity> query = _repository.GetByQuery();
        StatisticEntity? statisticEntity=
            await query.FirstOrDefaultAsync(cancellationToken);

        request.Statistic.Adapt(statisticEntity);
        await _repository.UpdateAsync(statisticEntity!,cancellationToken);
    }
}
