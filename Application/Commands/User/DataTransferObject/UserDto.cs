﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User.DataTransferObject;

public sealed record UserDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { set; get; }
    public string? UserName { set; get; }
    public string? Password { set; get; }
    public string? Role { set; get; }
}
