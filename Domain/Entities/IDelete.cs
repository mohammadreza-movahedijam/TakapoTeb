﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public interface IDelete
{
    public bool IsDeleted { get; set; }
}
