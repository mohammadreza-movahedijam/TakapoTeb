using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Product;

public sealed record ProductViewModel
{
    public Guid? Id { get; set; }
    public string? ImagePath { get; set; }
    public string? Title { get; set; }
    public string? CategoryTitle { get; set; }
    
}
