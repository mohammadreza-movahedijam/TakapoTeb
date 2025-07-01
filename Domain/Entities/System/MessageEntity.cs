﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class MessageEntity : BaseEntity, IDelete
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Subject { get; set; }
    public string? Text { get; set; }
    public bool IsDeleted { get; set ; }=false;
}

