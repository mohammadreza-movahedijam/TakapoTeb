using Application.Queries.ProductCategory.ViewModels;
using Application.Queries.ProductCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.TreatmentCenter;

namespace EndPointUI.Components;

public class ProductTreatmentCenterComponent(IMediator mediator):ViewComponent
{
    readonly IMediator _mediator=mediator;
    public async Task<IViewComponentResult> InvokeAsync(Guid Id)
    {
        IReadOnlyList<TreatmentCenterViewModel> model =
            await _mediator.Send(new GetTreatmentCenterByProductIdQuery()
            {
                    ProductId=Id,
            });
        return View("/Views/Shared/ViewComponent/ProductTreatmentCenterComponent.cshtml",
            model);
    }
}
