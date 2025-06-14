using Application.Queries.ProductCategory.ViewModels;
using Application.Queries.ProductCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class ProductFilterComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync(Guid Id)
    {
        IReadOnlyList<CategoryDetailViewModel> model =
              await _mediator.Send(new GetSubCategoriesForFilterQuery());
        return View("/Views/Shared/ViewComponent/ProductFilterComponent.cshtml",
            model);
    }
}
