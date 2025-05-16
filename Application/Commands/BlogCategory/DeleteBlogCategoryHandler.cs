using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.BlogCategory;

internal sealed class DeleteBlogCategoryHandler :
    IRequestHandler<DeleteBlogCategoryCommand>
{
    readonly IRepository<Domain.Entities.Blog.CategoryEntity> _repository;
    public DeleteBlogCategoryHandler
        (IRepository<Domain.Entities.Blog.CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteBlogCategoryCommand request, 
        CancellationToken cancellationToken)
    {
        Domain.Entities.Blog.CategoryEntity?
                  category = await _repository.
                  GetAsync(g => g.Id == request.Id, cancellationToken);
        if (category == null)
        {
            throw new InternalException(Message.NotFoundOnDb);
        }

        category.IsDeleted = true;
        await _repository.UpdateAsync(category, cancellationToken);
    }
}
