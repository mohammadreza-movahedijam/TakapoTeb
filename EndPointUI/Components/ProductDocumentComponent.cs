using Application.Queries.Document;
using Application.Queries.Image;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Components;

public class ProductDocumentComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync(Guid ProductId)
    {
        IReadOnlyList<DocumentViewModel> model =
            await _mediator.Send(new GetProductDocumentsByIdQuery()
            {
                ProductId = ProductId,
            });
        return View("/Views/Shared/ViewComponent/ProductDocumentComponent.cshtml", model);
    }
}
