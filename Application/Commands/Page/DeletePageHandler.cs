using Application.Commands.Page;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Page;

internal sealed class DeletePageHandler :
    IRequestHandler<DeletePageCommand>
{
    readonly IRepository<PageEntity> _PageRepository;
    public DeletePageHandler(IRepository<PageEntity> PageRepository)
    {
        _PageRepository = PageRepository;
    }
    public async Task Handle(DeletePageCommand request, CancellationToken cancellationToken)
    {
        PageEntity? Page = await _PageRepository.GetAsync(g => g.Id == request.Id, cancellationToken);
        if (Page == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        Page.IsDeleted = true;
        await _PageRepository.UpdateAsync(Page, cancellationToken);
    }
}
