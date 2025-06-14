using Application.Contract;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Image;

internal sealed class GetProductImagesByIdHandler :
    IRequestHandler<GetProductImagesByIdQuery, IReadOnlyList<ImageViewModel>>
{
    readonly IRepository<ImageEntity> _imageRepository;
    public GetProductImagesByIdHandler(IRepository<ImageEntity> imageRepository)
    {
        _imageRepository = imageRepository;
    }
    public async Task<IReadOnlyList<ImageViewModel>> Handle
        (GetProductImagesByIdQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ImageEntity> query = _imageRepository.GetByQuery();
        return await query.Where(w=>w.ProductId==request.ProductId).Select(s => new ImageViewModel()
        {
            Id = s.Id,
            Path = s.Path,
            TitleEn = s.TitleEn,
            TitleFa = s.TitleFa,
        }).ToListAsync();
    }
}
