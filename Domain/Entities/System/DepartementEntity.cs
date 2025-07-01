namespace Domain.Entities.System;

public class DepartementEntity : BaseEntity, IDelete
{
    public string? NameFa { get; set; }
    public string? NameEn { get; set; }
    public string? PhoneNumberEn { get; set; }
    public string? PhoneNumberFa { get; set; }

    public bool IsDeleted { get; set; } = false;
}
