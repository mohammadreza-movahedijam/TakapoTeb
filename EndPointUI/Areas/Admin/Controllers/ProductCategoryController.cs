using Application.Commands.ProductCategory;
using Application.Queries.ProductCategory;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductCategoryController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<ProductCategoryViewModel> pageModel =
            await _mediator.Send(new GetProductCategoriesQuery(pagination));
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await FetchParent();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductCategoryDto ProductCategory)
    {
        await _mediator.Send(new InsertProductCategoryCommand(ProductCategory));
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        await FetchParent();
        ProductCategoryDto ProductCategory = await _mediator.Send(new GetProductCategoryQuery(Id));
        return View(ProductCategory);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(ProductCategoryDto ProductCategory)
    {
        await _mediator.Send(new UpdateProductCategoryCommand(ProductCategory));
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteProductCategoryCommand(input.Id));
            return new JsonResult(new
            {
                IsSuccess = true,
                Message = string.Empty,
            });
        }
        catch (Exception ex)
        {
            return new JsonResult(new
            {
                IsSuccess = false,
                Message = ex.Message,
            });
        }
    }


    async Task FetchParent()
    {
        IReadOnlyList<ItemGeneric<Guid, string>>
            list = await _mediator.Send(new GetProductCategoryItemQuery());
        ViewBag.Parents = list;  
    }
}
