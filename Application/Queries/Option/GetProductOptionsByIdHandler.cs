using Application.Contract;
using Application.Queries.Image;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Option;

internal sealed class GetProductOptionsByIdHandler :
    IRequestHandler<GetProductOptionsByIdQuery, IReadOnlyList<OptionViewModel>>
{
    readonly IRepository<OptionEntity> _optionEntityRepository;
    public GetProductOptionsByIdHandler(IRepository<OptionEntity> optionEntityRepository)
    {
        _optionEntityRepository = optionEntityRepository;
    }
    public async Task<IReadOnlyList<OptionViewModel>>
        Handle(GetProductOptionsByIdQuery request, CancellationToken cancellationToken)
    {
        IQueryable<OptionEntity> query = _optionEntityRepository.GetByQuery();
        return await query.Where(w => w.ProductId == request.ProductId).
            Select(s => new OptionViewModel()
        {
            Id = s.Id,
            DescriptionFa = s.DescriptionFa,
            DescriptionEn=s.DescriptionEn,
            TitleEn = s.TitleEn,
            TitleFa = s.TitleFa,
            ImagePath=s.ImagePath
        }).ToListAsync();
    }
}
