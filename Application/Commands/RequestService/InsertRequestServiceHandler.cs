using Application.Commands.RequestService;
using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.RequestService;


internal sealed class InsertRequestServiceHandler :
    IRequestHandler<InsertRequestServiceCommand>
{
    readonly IRepository<RequestServiceAttachEntity> _ServiceAttachRepository;
    readonly IRepository<RequestServiceEntity> _ServiceRepository;
    readonly IContext _context;

    public InsertRequestServiceHandler
        (IRepository<RequestServiceEntity> ServiceRepository,
        IRepository<RequestServiceAttachEntity> ServiceAttachRepository,
        IContext context)
    {
        _ServiceAttachRepository = ServiceAttachRepository;
        _context = context;
        _ServiceRepository = ServiceRepository;
    }
    public async Task Handle(InsertRequestServiceCommand request,
        CancellationToken cancellationToken)
    {
        IExecutionStrategy strategy = _context.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            using (var transaction = await _context.BeginTransactionAsync())
            {
                try
                {
                    RequestServiceEntity requestService =
                         request.RequestService.Adapt<RequestServiceEntity>();
                    await _ServiceRepository.InsertAsync(requestService, cancellationToken);
                    if (request.RequestService!.Attachments != null)
                    {
                        List<RequestServiceAttachEntity> entities = [];
                        foreach (var item in request.RequestService!.Attachments)
                        {
                            RequestServiceAttachEntity attach = new()
                            {
                                RequestServiceId = requestService.Id,
                                FilePath = await item.UploadFileAsync("RequestService")
                            };
                            entities.Add(attach);
                        }
                        await _ServiceAttachRepository.InsertAsync(entities, cancellationToken);
                    }
                    await transaction.CommitAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);
                }
            }
        });
    }
}
