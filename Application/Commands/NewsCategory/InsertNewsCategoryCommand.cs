using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.NewsCategory;

public sealed record InsertNewsCategoryCommand:IRequest
{
    public NewsCategoryDto? NewsCategory { get; set; }
}
