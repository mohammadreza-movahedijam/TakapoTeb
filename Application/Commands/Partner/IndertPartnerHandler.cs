﻿using Application.Common.Extension;
using Application.Contract;
using Domain.Entities.System;
using MediatR;

namespace Application.Commands.Partner;

internal sealed class IndertPartnerHandler :
    IRequestHandler<IndertPartnerCommand>
{
    readonly IRepository<PartnerEntity> _partnerRepository;
    public IndertPartnerHandler(IRepository<PartnerEntity> partnerRepository)
    {
        _partnerRepository = partnerRepository;
    }
    public async Task Handle(IndertPartnerCommand request,
        CancellationToken cancellationToken)
    {
        PartnerEntity partner = new();
        partner.DescriptionEn = request.Partner.DescriptionEn;
        partner.DescriptionFa = request.Partner.DescriptionFa;
        partner.TitleEn = request.Partner.TitleEn;
        partner.TitleFa = request.Partner.TitleFa;
        partner.Link = request.Partner.Link;
        partner.LogoPath = request.Partner!.File!.UploadImage("partner");
        await _partnerRepository.InsertAsync(partner, cancellationToken);
    }
}
