﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class PartnerEntity:BaseEntity,IDelete
{
    public string? LogoPath {  get; set; }
    public string? Link { get; set; }
    public bool IsDeleted { get; set; } = false;
}
