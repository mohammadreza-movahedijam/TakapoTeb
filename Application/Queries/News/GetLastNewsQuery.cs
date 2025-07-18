﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.News;

public sealed record GetLastNewsQuery:IRequest<IReadOnlyList<NewsViewModel>>
{
}
