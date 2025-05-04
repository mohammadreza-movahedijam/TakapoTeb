using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User.DataTransferObject;

public sealed record UserDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage ="نام الزامی است")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "نام خانوادگی الزامی است")]
    public string? LastName { get; set; }
    [Required(ErrorMessage = "پست الکترونیک الزامی است")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "شماره موبایل الزامی است")]
    public string? PhoneNumber { set; get; }
    [Required(ErrorMessage = "کدملی الزامی است")]
    public string? UserName { set; get; }
    [Required(ErrorMessage = "گذر واژه الزامی است")]
    public string? Password { set; get; }
    [Required(ErrorMessage = "نقش الزامی است")]
    public string? Role { set; get; }
}
