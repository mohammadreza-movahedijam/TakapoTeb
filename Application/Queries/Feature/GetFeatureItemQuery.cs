﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Feature;

public sealed record GetFeatureItemQuery:IRequest<FeatureViewModel>
{
}
