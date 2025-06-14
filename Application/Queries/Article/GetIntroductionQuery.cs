using Application.Queries.Setting.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Article;

public sealed record GetIntroductionQuery:IRequest<IntroductionVieModel>
{
}
