using Application.Queries.Partner;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace EndPointUI.Components;

public class PartnerItemMobileMenuComponent(IMediator mediator) : ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<PartnerItemMenuViewModel> model =
            await _mediator.Send(new GetPartnerItemMenuQuery());
        return View("/Views/Shared/ViewComponent/PartnerItemMobileMenuComponent.cshtml",
            model);
    }
}
