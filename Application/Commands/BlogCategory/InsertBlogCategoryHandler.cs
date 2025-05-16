using Application.Contract;
using Mapster;
using MediatR;

namespace Application.Commands.BlogCategory;

internal sealed class InsertBlogCategoryHandler :
    IRequestHandler<InsertBlogCategoryCommand>
{
    readonly IRepository<Domain.Entities.Blog.CategoryEntity> _repository;
    public InsertBlogCategoryHandler
        (IRepository<Domain.Entities.Blog.CategoryEntity> repository)
    {
        _repository = repository;
    }
    public async Task Handle(InsertBlogCategoryCommand request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.Blog.CategoryEntity
            category = request.BlogCategory.
            Adapt<Domain.Entities.Blog.CategoryEntity>();
        await _repository.InsertAsync(category,cancellationToken);
    }
}
