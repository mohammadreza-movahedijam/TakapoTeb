using Application.Commands.Page;
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

namespace Application.Commands.Page;


internal sealed class InsertPageHandler :
    IRequestHandler<InsertPageCommand>
{
    readonly IRepository<PageEntity> _PageRepository;
    public InsertPageHandler(IRepository<PageEntity> PageRepository)
    {
        _PageRepository = PageRepository;
    }

    public async Task Handle(InsertPageCommand request,
        CancellationToken cancellationToken)
    {
        PageEntity Page = request.Page.Adapt<PageEntity>();
        if (request.Page!.File is not null)
        {
            Page.ImagePath = request.Page.File.UploadImage("Page");
        }
        await _PageRepository.InsertAsync(Page, cancellationToken);
    }
}