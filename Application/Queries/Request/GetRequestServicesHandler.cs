using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.Queries.Article.ViewModels;
using Domain.Entities.Blog;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Request;

internal sealed class GetRequestServicesHandler :
    IRequestHandler<GetRequestServicesQuery, PaginatedList<RequestViewModel>>
{

    readonly IRepository<RequestServiceEntity> _repository;
    public GetRequestServicesHandler(IRepository<RequestServiceEntity> repository)
    {
        _repository = repository;
    }
    public async Task<PaginatedList<RequestViewModel>>
        Handle(GetRequestServicesQuery request, CancellationToken cancellationToken)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<RequestServiceEntity, RequestViewModel>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.TreatmentCenterName, s => s.TreatmentCenterName)
            .Map(d => d.FullName, s => s.FullName)
            .Map(d => d.DeviceName, s => s.DeviceName)
            .Map(d => d.CreatedAt, s => s.CreatedAt!.Value.PersianDateWithTime())

      .Compile();

        IQueryable<RequestServiceEntity> query = _repository.GetByQuery();

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
            await query.MappingedAsync<RequestServiceEntity, RequestViewModel>
                (request!.Pagination!.curentPage,
                request!.Pagination!.pageSize, count, total, config);
        return model;
    }
}
