using Application.Queries.Article.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Article;

public sealed record GetLastArticleQuery:
    IRequest<IReadOnlyList<ArticleViewModel>>
{
}
