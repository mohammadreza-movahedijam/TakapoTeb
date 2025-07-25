using Microsoft.AspNetCore.Http;

namespace Application.Commands.TreatmentCenter;

public sealed record TreatmentCenterDto
{
    public Guid Id { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }

    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }
    public string? PhoneNumber { get; set; }

    public Guid ProductId { get; set; }


    public string? Latitude { set; get; }
    public string? Longitude { set; get; }
}
