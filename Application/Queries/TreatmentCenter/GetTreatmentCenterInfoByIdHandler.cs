using Application.Contract;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.TreatmentCenter;

internal sealed class GetTreatmentCenterInfoByIdHandler :
    IRequestHandler<GetTreatmentCenterInfoByIdQuery, TreatmentCenterInfoViewModel>
{
    readonly IRepository<TreatmentCenterEntity> _repository;
    public GetTreatmentCenterInfoByIdHandler(IRepository<TreatmentCenterEntity> repository)
    {
        _repository = repository;
    }

    public async Task<TreatmentCenterInfoViewModel> Handle(GetTreatmentCenterInfoByIdQuery request, CancellationToken cancellationToken)
    {
        IQueryable<TreatmentCenterEntity> query = _repository.GetByQuery();
        query = query.Include(i => i.Product);
        TreatmentCenterInfoViewModel? model= await query.Where(w => w.Id == request.Id)
            .Select(s=>new TreatmentCenterInfoViewModel()
            {
                Id = s.Id,
                DescriptionEn   = s.DescriptionEn,
                DescriptionFa = s.DescriptionFa,
                PhoneNumber = s.PhoneNumber,
                ProductTitleEn=s.Product!.TitleEn,
                TitleEn=s.TitleEn,
                ProductTitleFa=s.Product.TitleFa,
                TitleFa=s.TitleFa
            }).FirstOrDefaultAsync() ;
        return model!;
    }
}
