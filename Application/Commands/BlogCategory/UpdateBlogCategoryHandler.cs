using Application.Contract;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.BlogCategory;

internal sealed class UpdateBlogCategoryHandler :
    IRequestHandler<UpdateBlogCategoryCommand>
{
    readonly IRepository<Domain.Entities.Blog.CategoryEntity> _repository;
    public UpdateBlogCategoryHandler
        (IRepository<Domain.Entities.Blog.CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateBlogCategoryCommand request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.Blog.CategoryEntity?
                   category = await _repository.
                   GetAsync(g => g.Id == request.BlogCategory.Id, cancellationToken);
        if (category == null) 
        {
            throw new InternalException(Message.NotFoundOnDb);
        }

        request.BlogCategory.Adapt(category);
        await _repository.UpdateAsync(category,cancellationToken);
    }
}
