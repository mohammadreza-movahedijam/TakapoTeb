using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.Product;
using MediatR;

namespace Application.Commands.Image;

internal sealed class InsertImageHandler :
    IRequestHandler<InsertImageCommand>
{
    readonly IRepository<ImageEntity> _repository;
    public InsertImageHandler(IRepository<ImageEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertImageCommand request,
        CancellationToken cancellationToken)
    {
        ImageEntity image = new()
        {
            ProductId = request.Image!.ProductId,
            TitleEn = request.Image.TitleEn,
            TitleFa = request.Image.TitleFa,
            Path = request.Image.File!.UploadImage("ProductImage")
        };
        await _repository.InsertAsync(image, cancellationToken);
    }
}
