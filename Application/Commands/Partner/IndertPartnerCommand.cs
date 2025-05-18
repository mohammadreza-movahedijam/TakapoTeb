using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Partner;

public sealed record IndertPartnerCommand:IRequest
{
    public PartnerDto Partner {  get; set; }
    public IndertPartnerCommand(PartnerDto Partner)
    {
        this.Partner = Partner;
    }
}
