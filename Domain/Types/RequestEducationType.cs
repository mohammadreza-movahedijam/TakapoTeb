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
    Primary=0,
    [Display(Name = "آموزش مجدد")]
    Repeated=1,
    [Display(Name = "آموزش تکمیلی")]
    Complete=2
}
