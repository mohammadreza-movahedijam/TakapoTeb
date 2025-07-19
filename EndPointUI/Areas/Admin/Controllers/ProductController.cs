using Application.Commands.Product;
using Application.Queries.Product;
using Application.Queries.Product.ViewModels;
using Application.Queries.ProductCategory;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Product")]
public class ProductController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<ProductViewModel> pageModel =
            await _mediator.Send(new GetProductsQuery(pagination));
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto Product)
    {
        await _mediator.Send(new InsertProductCommand(Product));
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {

        ProductDto Product = await _mediator.Send(new GetProductQuery(Id));
        return View(Product);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(ProductDto Product)
    {
        await _mediator.Send(new UpdateProductCommand(Product));
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteProductCommand(input.Id));
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

    [HttpGet]
    public async Task<IActionResult> FetchCategory(string search)
    {
        var items = await _mediator.Send(new GetProductCategoryItemQuery()
        {
            Search = search
        });

        return Json(new
        {
            items = items.Select(i => new
            {
                id = i.Id,
                text = i.Title
            })
        });
    }
    [HttpGet]
    public async Task<IActionResult> GetRelatedProducts(string search, string? Id = null)
    {
        Guid ProductId = Guid.Empty;
        if (Id != null)
        {
            ProductId = Guid.Parse(Id!);
        }
        var items = await _mediator.Send(new GetRelatedProductsQuery()
        {
            ProductName = search,
            ProductId = ProductId
        });

        return Json(new
        {
            items = items.Select(i => new
            {
                id = i.Id,
                text = i.Title
            })
        });
    }


    [HttpGet]
    public async Task<IActionResult> GetRelateds(string? Id = null)
    {
       
        var items = await _mediator.Send(new GetRelatedProductQuery()
        {
           Id = Guid.Parse(Id!)
        });

        return Json(new
        {
            items = items.Select(i => new
            {
                id = i.Id,
                text = i.Title
            })
        });
    }




}
