using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Feedback;

public sealed record FeedbackViewModel
{
    public Guid Id { get; set; }
    public string? FullNameFa { get; set; }
    public string? JobPositionFa { get; set; }
    public string? ExplanationFa { get; set; }
    public string? FullNameEn { get; set; }
    public string? JobPositionEn { get; set; }
    public string? ExplanationEn { get; set; }
}
