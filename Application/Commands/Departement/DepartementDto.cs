using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Departement;

public sealed record DepartementDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage ="نام فارسی الزامی است")]
    public string? NameFa { get; set; }
    [Required(ErrorMessage = "نام انگلیسی الزامی است")]
    public string? NameEn { get; set; }
    [Required(ErrorMessage = "شماره انگلیسی الزامی است")]
    public string? PhoneNumberEn { get; set; }
    [Required(ErrorMessage = "شماره فارسی الزامی است")]
    public string? PhoneNumberFa { get; set; }
}
