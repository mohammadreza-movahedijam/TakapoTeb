using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Event;

public sealed record EventDetailViewModel
{
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    public List<EventVideoViewModel>? Videos { get; set; }
    public List<EventPictureViewModel>? Pictures { get; set; }

}
public sealed record EventVideoViewModel
{
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public string? Link { set; get; }
}
public sealed record EventPictureViewModel
{
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public string? FilePath { set; get; }
}