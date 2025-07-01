﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Departement;

public sealed record GetDepartementsWithOutPaginationQuery:
    IRequest<IReadOnlyList<DepartementViewModel>>
{
}
