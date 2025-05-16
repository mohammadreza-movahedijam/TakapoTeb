using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Article;

public sealed record InsertArticleCommand:IRequest
{
    public ArticleDto Article {  get; set; }
    public InsertArticleCommand(ArticleDto Article)
    {
        this.Article = Article;
    }
}
