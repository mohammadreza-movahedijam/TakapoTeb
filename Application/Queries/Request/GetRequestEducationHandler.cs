using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Queries.Request;

internal sealed class GetRequestEducationHandler :
    IRequestHandler<GetRequestEducationQuery, RequestEducationDetailViewModel>
{
    readonly IRepository<RequestEducationEntity> _educationRepository;
    readonly IRepository<RequestEducationAttachEntity> _attachRepository;
    public GetRequestEducationHandler(
        IRepository<RequestEducationEntity> educationRepository,
        IRepository<RequestEducationAttachEntity> attachRepository
        )
    {
        _attachRepository = attachRepository;
        _educationRepository = educationRepository;
    }

    public async Task<RequestEducationDetailViewModel> Handle
        (GetRequestEducationQuery request, CancellationToken cancellationToken)
    {
        RequestEducationEntity? requestEducation =
            await _educationRepository.GetAsync(g => g.Id == 
            request.Id, cancellationToken);
        List<RequestEducationAttachEntity>? requestEducationAttach =
            await _attachRepository.GetListAsync
            (g => g.RequestEducationId == 
            request.Id);


        List<string> files = [];
        RequestEducationDetailViewModel detail = new();

        detail.TreatmentCenterName = requestEducation!.TreatmentCenterName;
        detail.FullName = requestEducation.FullName;
        detail.DeviceName = requestEducation.DeviceName;
        detail.DeviceSerialNumber = requestEducation.DeviceSerialNumber;
        detail.Description = requestEducation.Description;
        detail.Mobile = requestEducation.Mobile;
        detail.EducationType = requestEducation.EducationType.GetEnumName();
        detail.CreatedAt = requestEducation.CreatedAt!.Value.PersianDateWithTime();
        if (requestEducationAttach != null)
        {
            foreach(var item in requestEducationAttach)
            {
                files.Add(item.FilePath!);
            }
            detail.Files = files;
        }
        return detail;
    }
}
