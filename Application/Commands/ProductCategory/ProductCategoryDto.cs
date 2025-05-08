using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductCategory;

public sealed record ProductCategoryDto
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }

    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }

    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
}
