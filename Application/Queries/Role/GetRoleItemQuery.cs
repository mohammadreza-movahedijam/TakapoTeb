﻿using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Role;

public sealed record GetRoleItemQuery:IRequest<List<ItemGeneric<Guid, string>>>
{
}
