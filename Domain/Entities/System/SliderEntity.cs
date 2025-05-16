namespace Domain.Entities.System;

public class SliderEntity : BaseEntity, IDelete
{
    public string? ImagePath { get; set; }
    public string? Title { get; set; }
    public string? Alt { get; set; }
    public string? Link { get; set; }
    public bool IsDeleted { get; set; } = false;
}
