using Application.Contract;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Departement;

internal sealed class GetDepartementsWithOutPaginationHandler :
    IRequestHandler<GetDepartementsWithOutPaginationQuery,
        IReadOnlyList<DepartementViewModel>>
{

    readonly IRepository<DepartementEntity> _repository;

    public GetDepartementsWithOutPaginationHandler(IRepository<DepartementEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<DepartementViewModel>>
        Handle(GetDepartementsWithOutPaginationQuery request, CancellationToken cancellationToken)
    {
        IQueryable<DepartementEntity> query =
             _repository.GetByQuery();
        return await query.Select(s => new DepartementViewModel()
        {
            Id = s.Id,
            NameEn = s.NameEn,
            NameFa = s.NameFa,
            PhoneNumberEn = s.PhoneNumberEn,
            PhoneNumberFa = s.PhoneNumberFa
        }).ToListAsync(cancellationToken);
    }
}
