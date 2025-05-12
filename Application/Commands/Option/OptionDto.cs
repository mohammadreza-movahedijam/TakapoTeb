using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Option;

public sealed record OptionDto
{
    public Guid Id { get; set; }
    public string? TitleFa { set; get; }
    public string? DescriptionFa { set; get; }
    public string? TitleEn { set; get; }
    public string? DescriptionEn { set; get; }
    public string? ImagePath { set; get; }
    public IFormFile? ImageFile { set; get; }   
    public Guid ProductId { set; get; }
    public string? ProductTitleFa { set; get;}
}
