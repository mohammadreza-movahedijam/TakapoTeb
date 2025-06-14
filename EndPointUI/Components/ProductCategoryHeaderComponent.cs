using Application.Queries.ProductCategory;
using Application.Queries.Article;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.ProductCategory.ViewModels;

namespace EndPointUI.Components;

public class ProductCategoryHeaderComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync(Guid Id)
    {
        CategoryDetailViewModel model =
            await _mediator.Send(new GetCategoryDetailQuery(Id));
        return View("/Views/Shared/ViewComponent/ProductCategoryHeaderComponent.cshtml", model);
    }
}
