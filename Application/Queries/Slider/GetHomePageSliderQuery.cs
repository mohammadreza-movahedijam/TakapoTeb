using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Slider;

public sealed record GetHomePageSliderQuery:
    IRequest<IReadOnlyList<SliderViewModel>>
{
}
