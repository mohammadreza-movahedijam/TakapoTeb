using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types;

public enum RequestEducationType
{
    [Display(Name ="آموزش اولیه")]
    Primary,
    [Display(Name = "آموزش مجدد")]
    Repeated,
    [Display(Name = "آموزش تکمیلی")]
    Complete
}
