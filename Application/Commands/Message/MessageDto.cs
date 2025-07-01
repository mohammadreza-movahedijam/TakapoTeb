using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Message;

public sealed record MessageDto
{
    public Guid Id { get; set; }
    [Required]
    public string? FullName { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? PhoneNumber { get; set; }
    [Required]
    public string? Subject { get; set; }
    [Required]
    public string? Text { get; set; }
}
