using Application.Contract;
using Domain.Entities.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Image;

internal sealed class GetImagesHandler :
    IRequestHandler<GetImagesQuery, IReadOnlyList<ImageViewModel>>
{
    readonly IRepository<ImageEntity> _imageRepository;
    public GetImagesHandler(IRepository<ImageEntity> imageRepository)
    {
        _imageRepository = imageRepository;
    }
    public async Task<IReadOnlyList<ImageViewModel>> Handle(GetImagesQuery request, 
        CancellationToken cancellationToken)
    {
        IQueryable<ImageEntity> query = _imageRepository.GetByQuery();
        return await query.Select(s=>new ImageViewModel()
        {
            Id = s.Id,
            Path = s.Path,
            TitleEn=s.TitleEn,
            TitleFa = s.TitleFa,
        }).ToListAsync();
    }
}
