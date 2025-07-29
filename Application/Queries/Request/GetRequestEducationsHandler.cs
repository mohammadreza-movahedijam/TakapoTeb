using Application.Common;
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

namespace Application.Queries.Request;

internal class GetRequestEducationsHandler :
      IRequestHandler<GetRequestEducationsQuery, PaginatedList<RequestViewModel>>
{
    readonly IRepository<RequestEducationEntity> _repository;
    public GetRequestEducationsHandler
        (IRepository<RequestEducationEntity> repository)
    {
        _repository = repository;
    }

    public async Task<PaginatedList<RequestViewModel>>
        Handle(GetRequestEducationsQuery request, 
        CancellationToken cancellationToken)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<RequestEducationEntity, RequestViewModel>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.TreatmentCenterName, s => s.TreatmentCenterName)
            .Map(d => d.FullName, s => s.FullName).Map(d => d.IsSeen, s => s.IsSeen)
            .Map(d => d.DeviceName, s => s.DeviceName)
            .Map(d => d.CreatedAt, s => s.CreatedAt!.Value.PersianDateWithTime())

      .Compile();

        IQueryable<RequestEducationEntity> query = _repository.GetByQuery();

        if (!string.IsNullOrEmpty(request!.Pagination!.keyword))
        {
            query = query.Where(w =>

            w.TreatmentCenterName!.Contains(request!.Pagination!.keyword)
            || w.FullName!.Contains(request!.Pagination!.keyword)
                        || w.DeviceSerialNumber!.Contains(request!.Pagination!.keyword) ||
            w.DeviceName!.Contains(request!.Pagination!.keyword));
        }
        int count = query.Count().PageCount(request!.Pagination!.pageSize); ;
        int total = query.Count();

        PaginatedList<RequestViewModel> model =
            await query.MappingedAsync<RequestEducationEntity, RequestViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total, config);
        return model;
    }
}
