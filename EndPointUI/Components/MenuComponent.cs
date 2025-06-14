using Application.Queries.Setting.ViewModels;
using Application.Queries.Setting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.ProductCategory.ViewModels;
using Application.Queries.ProductCategory;

namespace EndPointUI.Components;

public class MenuComponent(IMediator mediator) :ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<CategoryMenuViewModel> model =
            await _mediator.Send(new GetCategoryMenuQuery());
        return View("/Views/Shared/ViewComponent/MenuComponent.cshtml", model);
    }
}
