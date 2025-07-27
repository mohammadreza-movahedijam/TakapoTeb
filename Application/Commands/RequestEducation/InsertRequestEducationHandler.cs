using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Commands.RequestEducation;

internal sealed class InsertRequestEducationHandler :
    IRequestHandler<InsertRequestEducationCommand>
{
    readonly IRepository<RequestEducationAttachEntity> _educationAttachRepository;
    readonly IRepository<RequestEducationEntity> _educationRepository;
    readonly IContext _context;

    public InsertRequestEducationHandler
        (IRepository<RequestEducationEntity> educationRepository,
        IRepository<RequestEducationAttachEntity> educationAttachRepository,
        IContext context)
    {
        _educationAttachRepository = educationAttachRepository;
        _context = context;
        _educationRepository = educationRepository;
    }
    public async Task Handle(InsertRequestEducationCommand request,
        CancellationToken cancellationToken)
    {
        IExecutionStrategy strategy = _context.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            using (var transaction = await _context.BeginTransactionAsync())
            {
                try
                {
                    RequestEducationEntity requestEducation =
                         request.RequestEducation.Adapt<RequestEducationEntity>();
                    await _educationRepository.InsertAsync(requestEducation, cancellationToken);
                    if (request.RequestEducation!.Attachments != null)
                    {
                        List<RequestEducationAttachEntity> entities = [];
                        foreach (var item in request.RequestEducation!.Attachments)
                        {
                            RequestEducationAttachEntity attach = new()
                            {
                                RequestEducationId = requestEducation.Id,
                                FilePath = await item.UploadFileAsync("RequestEducation")
                            };
                            entities.Add(attach);
                        }
                        await _educationAttachRepository.InsertAsync(entities,cancellationToken);
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
