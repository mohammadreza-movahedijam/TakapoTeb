using Application.Queries.Article;
using Application.Queries.Product;
using Application.Queries.Product.ViewModels;
using Application.Queries.Setting.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class RelatedProductsComponent(IMediator mediator):ViewComponent
{
    readonly IMediator _mediator = mediator;

    public async Task<IViewComponentResult> InvokeAsync(Guid Id)
    {
        IReadOnlyList<ProductViewModel> model =
            await _mediator.Send(new GetRelatesQuery()
            {
                ProductId= Id
            });
        return View("/Views/Shared/ViewComponent/RelatedProductsComponent.cshtml",
            model);
    }
}
