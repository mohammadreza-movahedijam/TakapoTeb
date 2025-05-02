using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Role.DataTransferObject;

public sealed record RoleDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage ="نام سیستمی الزامی است")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "نام الزامی است")]
    public string? PersianName { get; set; }

}
