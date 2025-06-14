using Application.Queries.ProductCategory;
using Application.Queries.ProductCategory.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Controllers;

public class CategoryController (IMediator mediator): Controller
{
    readonly IMediator _mediator=mediator;   
    public async Task<IActionResult> Detail(Guid pattern)
    {
        CategoryDetailViewModel categoryViewModel = 
            await _mediator.Send(new GetCategoryDetailQuery(pattern));
        return View(categoryViewModel);
    }
}
