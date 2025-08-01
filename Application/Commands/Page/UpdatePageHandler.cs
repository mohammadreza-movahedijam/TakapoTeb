using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;

namespace Application.Commands.Page;

internal sealed class UpdatePageHandler :
    IRequestHandler<UpdatePageCommand>
{
    readonly IRepository<PageEntity> _PageRepository;
    public UpdatePageHandler(IRepository<PageEntity> PageRepository)
    {
        _PageRepository = PageRepository;
    }
    public async Task Handle(UpdatePageCommand request, CancellationToken cancellationToken)
    {
        PageEntity? Page = await _PageRepository.GetAsync(g => g.Id == request.Page!.Id, cancellationToken);
        if (Page == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        request.Page!.Adapt(Page);
        if (request.Page!.File is not null)
        {
            Page.ImagePath = request.Page.File.UploadImage("Page");
            request.Page.ImagePath!.RemoveImage("Page");
        }
        await _PageRepository.UpdateAsync(Page, cancellationToken);

    }
}
