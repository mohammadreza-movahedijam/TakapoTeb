using Application.Contract;
using Domain.Entities.Product;
using MediatR;

namespace Application.Commands.Image;

internal sealed class DeleteImageHandler :
    IRequestHandler<DeleteImageCommand>
{
    readonly IRepository<ImageEntity> _imageRepository;
    public DeleteImageHandler(IRepository<ImageEntity> imageRepository)
    {
        _imageRepository = imageRepository;
    }
    public async Task Handle(DeleteImageCommand request,
        CancellationToken cancellationToken)
    {
        ImageEntity? image = await _imageRepository.
             GetAsync(g => g.Id == request.Id);
        image.IsDeleted= true;
        await _imageRepository.UpdateAsync(image);
    }
}
