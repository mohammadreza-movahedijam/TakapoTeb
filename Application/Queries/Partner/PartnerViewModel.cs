using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Partner;
public sealed record PartnerViewModel
{
    public Guid Id { get; set; }
    public string? TitleFa { get; set; }
    public string? LogoPath { get; set; }
    public string? Link { get; set; }
}
