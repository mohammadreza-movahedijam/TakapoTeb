using Domain.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.News;

public sealed record NewsDetailViewModel
{
    public Guid Id { get; set; }
    public string? ImagePath { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public TopicType TopicType { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    public string? ReferencesLink { set; get; }
}
