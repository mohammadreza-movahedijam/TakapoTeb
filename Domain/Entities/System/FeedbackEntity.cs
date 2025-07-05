namespace Domain.Entities.System;

public class FeedbackEntity : BaseEntity,IDelete
{
    public string? FullNameFa { get; set; }
    public string? JobPositionFa { get; set; }    
    public string? ExplanationFa { get; set; }


    public string? FullNameEn { get; set; }
    public string? JobPositionEn { get; set; }
    public string? ExplanationEn { get; set; }

    public bool IsDeleted { get ; set ; }=false;
}
