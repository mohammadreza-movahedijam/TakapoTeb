using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Article;

public sealed record DeleteArticleCommand:IRequest
{
    public Guid Id { get; set; }
    public DeleteArticleCommand(in Guid Id)
    {
        this.Id = Id;
    }
}
