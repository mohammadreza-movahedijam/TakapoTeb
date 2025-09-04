using Application.Common;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Page;

internal sealed class GetPageItemHandler :
    IRequestHandler<GetPageItemQuery, IReadOnlyList<ItemGeneric<Guid, string>>>
{
    readonly IRepository<PageEntity> _repository;
    public GetPageItemHandler(IRepository<PageEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<ItemGeneric<Guid, string>>>
        Handle(GetPageItemQuery request, CancellationToken cancellationToken)
    {
        IQueryable<PageEntity> query = _repository.GetByQuery();

        return await query.Select(s => new ItemGeneric<Guid, string>
        {
            Id = s.Id,
            Title = s.TitleFa + "-" + s.TitleEn
        }).ToListAsync(cancellationToken);
    }
}
