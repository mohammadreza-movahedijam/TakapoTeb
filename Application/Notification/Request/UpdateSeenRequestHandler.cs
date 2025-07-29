using Application.Contract;
using Domain.Entities.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notification.Request;

internal sealed class UpdateSeenRequestHandler :
    INotificationHandler<UpdateSeenRequestNotification>
{
    readonly IRepository<RequestEducationEntity> _educationRepository;
    readonly IRepository<RequestServiceEntity> _serviceRepository;
    public UpdateSeenRequestHandler
        (
        IRepository<RequestEducationEntity> educationRepository,
        IRepository<RequestServiceEntity> serviceRepository
        )
    {
        _educationRepository = educationRepository;
        _serviceRepository = serviceRepository;
    }

    public async Task Handle(UpdateSeenRequestNotification request,
        CancellationToken cancellationToken)
    {
        if (request.IsService)
        {
            _serviceRepository.SetEntity()
                .Where(w=>w.Id==request.Id)
                .ExecuteUpdate(e=>e.SetProperty(s=>s.IsSeen,true));
        }
        else
        {
            _educationRepository.SetEntity()
              .Where(w => w.Id == request.Id)
              .ExecuteUpdate(e => e.SetProperty(s => s.IsSeen, true));
        }
    }
}
