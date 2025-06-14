using Application.Queries.Setting.ViewModels;
using Application.Queries.Setting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.ProductCategory.ViewModels;
using Application.Queries.ProductCategory;
namespace EndPointUI.Components;

public class SubCategoriesComponent (IMediator mediator) :ViewComponent
{
    readonly IMediator _mediator = mediator;
    public async Task<IViewComponentResult> InvokeAsync( Guid Id)
    {
      IReadOnlyList<CategoryDetailViewModel> model =
            await _mediator.Send(new GetSubCategoriesQuery(Id));
        return View("/Views/Shared/ViewComponent/SubCategoriesComponent.cshtml", model);
    }
}
