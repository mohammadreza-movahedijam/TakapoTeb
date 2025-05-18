using Application.Contract;
using Domain.Entities.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Partner;

internal sealed class DeletePartnerHandler :
    IRequestHandler<DeletePartnerCommand>
{

    readonly IRepository<PartnerEntity> _partnerRepository;
    public DeletePartnerHandler(IRepository<PartnerEntity> partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }
    public async Task Handle(DeletePartnerCommand request, 
        CancellationToken cancellationToken)
    {
        PartnerEntity? partner = await _partnerRepository
           .GetAsync(g => g.Id == request.Id, cancellationToken);
        if (partner == null)
        {
            throw new InternalException(Message.NotFoundOnDb);
        }
        partner.IsDeleted = true;
        await _partnerRepository.UpdateAsync(partner, cancellationToken);
    }
}
