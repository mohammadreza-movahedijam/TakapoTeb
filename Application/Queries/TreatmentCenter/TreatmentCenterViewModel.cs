namespace Application.Queries.TreatmentCenter;

public sealed record TreatmentCenterViewModel
{
    public Guid Id { get; set; }
    public string? Image { get; set; }
    public string? Latitude { set; get; }
    public string? Longitude { set; get; }
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }

}
