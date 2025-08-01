using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Picture;

public sealed record PictureDto
{
    public Guid? EventId { get; set; }
    public Guid? Id { get; set; }

    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public string? FilePath { set; get; }
    public IFormFile? File { set; get; }
}
