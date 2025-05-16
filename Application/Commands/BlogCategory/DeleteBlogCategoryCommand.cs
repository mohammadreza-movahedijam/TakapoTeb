using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.BlogCategory;

public sealed record DeleteBlogCategoryCommand:
    IRequest
{
    public Guid Id { get; set; }
    public DeleteBlogCategoryCommand(in Guid Id)
    {
        this.Id = Id;
    }
}
