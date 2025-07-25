using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types;
public enum FileType
{
    [Display(Name = "کاتالوگ")]
    Catalog,
    [Display(Name = "کتاب کار")]
    Book
}
