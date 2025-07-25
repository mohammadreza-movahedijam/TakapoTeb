using Domain.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Catalog;

public sealed record CatalogViewModel
{
    public Guid Id { get; set; }
    public FileType Type { get; set; }
    public string? TitleFa { get; set; }
}
