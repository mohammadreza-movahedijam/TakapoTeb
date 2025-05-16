using Application.Commands.BlogCategory;
using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.BlogCategory;

internal sealed class GetBlogCategoryHandler :
    IRequestHandler<GetBlogCategoryQuery, BlogCategoryDto>
{


    readonly IRepository<Domain.Entities.Blog.CategoryEntity> _repository;
    public GetBlogCategoryHandler
        (IRepository<Domain.Entities.Blog.CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task<BlogCategoryDto> Handle(GetBlogCategoryQuery request, CancellationToken cancellationToken)
    {
        BlogCategoryDto?
                   category = await _repository.
                   GetAsync<BlogCategoryDto>(g => g.Id == request.Id,null,
                   cancellationToken);
        if (category == null)
        {
            throw new InternalException(Message.NotFoundOnDb);
        }
        return category;
    }
}
