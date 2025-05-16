using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Slider;
public sealed record SliderViewModel
{
    public Guid? Id { get; set; }
    public string? ImagePath { get; set; }
    public string? Title { get; set; }
    public string? Alt { get; set; }
    public string? Link { get; set; }
}
