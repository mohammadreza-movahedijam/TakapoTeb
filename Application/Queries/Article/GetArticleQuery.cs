using Application.Commands.Article;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Article;

public sealed record GetArticleQuery:IRequest<ArticleDto>
{
    public Guid Id { get; set; }
    public GetArticleQuery(in Guid Id)
    {
        this.Id = Id;
    }
}
