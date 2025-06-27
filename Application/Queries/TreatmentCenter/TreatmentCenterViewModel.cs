namespace Application.Queries.TreatmentCenter;

public sealed record TreatmentCenterViewModel
{
    public Guid Id { get; set; }

    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }

}
