using Application.Queries.Setting.ViewModels;
using Application.Queries.Setting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.Image;

namespace EndPointUI.Components;

public class ProductImageComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync(Guid ProductId)
    {
        IReadOnlyList<ImageViewModel> model =
            await _mediator.Send(new GetProductImagesByIdQuery()
            {
                ProductId=ProductId,
            });
        return View("/Views/Shared/ViewComponent/ProductImageComponent.cshtml", model);
    }
}
