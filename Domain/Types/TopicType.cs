using System.ComponentModel.DataAnnotations;

namespace Domain.Types;

public enum TopicType
{
    [Display(Name = "اخبار شرکت",ShortName = "Company News")]
    CompanyNews,
    [Display(Name = "مسئولیت اجتماعی", ShortName = "Social Responsibility")]
    SocialResponsibility,
    [Display(Name = "اخبار محصول", ShortName = "Product News")]
    ProductNews,
    [Display(Name = "نوآوری", ShortName = "Innovation")]
    Innovation,
    [Display(Name = "رویداد", ShortName = "Event")]
    Event
}
