using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Departement;

public sealed  record   DepartementViewModel
{
    public Guid Id { get; set; }
    public string? NameFa { get; set; }
    public string? NameEn { get; set; }
    public string? PhoneNumberEn { get; set; }
    public string? PhoneNumberFa { get; set; }
}
