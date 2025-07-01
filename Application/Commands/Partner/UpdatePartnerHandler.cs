using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Commands.Partner;

internal sealed class UpdatePartnerHandler :
    IRequestHandler<UpdatePartnerCommand>
{
    readonly IRepository<PartnerEntity> _partnerRepository;
    public UpdatePartnerHandler(IRepository<PartnerEntity> partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }
    public async Task Handle(UpdatePartnerCommand request,
        CancellationToken cancellationToken)
    {
        PartnerEntity? partner = await _partnerRepository
            .GetAsync(g => g.Id == request.Partner.Id, cancellationToken);
        if (partner == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        partner.Link = request.Partner.Link;
        if (request.Partner.File is not null)
        {
            partner.LogoPath = request.Partner!.File!.UploadImage("partner");
            request.Partner.LogoPath!.RemoveImage("partner");
        }
        await _partnerRepository.UpdateAsync(partner, cancellationToken);
    }
}
