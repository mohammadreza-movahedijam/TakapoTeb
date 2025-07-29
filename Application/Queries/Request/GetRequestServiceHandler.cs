using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Request;

internal sealed class GetRequestServiceHandler :
    IRequestHandler<GetRequestServiceQuery, RequestServiceDetailViewModel>
{

    readonly IRepository<RequestServiceEntity> _serviceRepository;
    readonly IRepository<RequestServiceAttachEntity> _attachRepository;
    public GetRequestServiceHandler(
        IRepository<RequestServiceEntity> serviceRepository,
        IRepository<RequestServiceAttachEntity> attachRepository
        )
    {
        _attachRepository = attachRepository;
        _serviceRepository = serviceRepository;
    }

    public async Task<RequestServiceDetailViewModel> Handle
        (GetRequestServiceQuery request, CancellationToken cancellationToken)
    {
        RequestServiceEntity? requestEducation =
           await _serviceRepository.GetAsync(g => g.Id ==
           request.Id, cancellationToken);
        List<RequestServiceAttachEntity>? requestServiceAttach =
            await _attachRepository.GetListAsync
            (g => g.RequestServiceId ==
            request.Id);


        List<string> files = [];
        RequestServiceDetailViewModel detail = new();

        detail.TreatmentCenterName = requestEducation!.TreatmentCenterName;
        detail.FullName = requestEducation.FullName;
        detail.DeviceName = requestEducation.DeviceName;
        detail.DeviceSerialNumber = requestEducation.DeviceSerialNumber;
        detail.Description = requestEducation.Description;
        detail.Mobile = requestEducation.Mobile;
        detail.RequestType = requestEducation.RequestType.GetEnumName();
        detail.CreatedAt = requestEducation.CreatedAt!.Value.PersianDateWithTime();
        if (requestServiceAttach != null)
        {
            foreach (var item in requestServiceAttach)
            {
                files.Add(item.FilePath!);
            }
            detail.Files = files;
        }
        return detail;
    }
}
