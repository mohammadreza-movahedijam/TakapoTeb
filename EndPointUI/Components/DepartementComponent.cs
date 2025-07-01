using Application.Queries.Article.ViewModels;
using Application.Queries.Article;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.Departement;

namespace EndPointUI.Components;

public class DepartementComponent(IMediator mediator):ViewComponent
{
    readonly IMediator _mediator=mediator;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<DepartementViewModel> model =
           await _mediator.Send(new GetDepartementsWithOutPaginationQuery());
        return View("/Views/Shared/ViewComponent/DepartementComponent.cshtml", model);
    }
}
