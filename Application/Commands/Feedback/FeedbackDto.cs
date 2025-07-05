using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Feedback;

public sealed record FeedbackDto
{
    public Guid Id { get; set; }
    public string? FullNameFa { get; set; }
    public string? JobPositionFa { get; set; }
    public string? ExplanationFa { get; set; }


    public string? FullNameEn { get; set; }
    public string? JobPositionEn { get; set; }
    public string? ExplanationEn { get; set; }
}
