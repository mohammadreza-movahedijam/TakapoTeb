﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Video;

public sealed record DeleteVideoCommand:IRequest
{
    public Guid Id  { get; set; }
}
