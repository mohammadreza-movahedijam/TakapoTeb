using Application.Queries.Document;
using Application.Queries.Option;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class ProductOptionComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync(Guid ProductId)
    {
        IReadOnlyList<OptionViewModel> model =
            await _mediator.Send(new GetProductOptionsByIdQuery()
            {
                ProductId = ProductId,
            });
        return View("/Views/Shared/ViewComponent/ProductOptionComponent.cshtml", model);
    }
}
