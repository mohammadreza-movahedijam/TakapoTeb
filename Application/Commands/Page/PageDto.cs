using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Page;

public sealed record PageDto
{
    public Guid Id { get; set; }
    public IFormFile? File { get; set; }
    public string? ImagePath { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }
    public bool IsShowOnMenu { get; set; }
    public Guid? ParentPageId { get; set; }
    public bool IsActivePage { get; set; }

}
