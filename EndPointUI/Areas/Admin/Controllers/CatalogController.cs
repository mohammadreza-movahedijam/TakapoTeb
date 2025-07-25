using Application.Commands.Catalog;
using Application.Queries.Catalog;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;


[Area("Admin")]
public class CatalogController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<CatalogViewModel> pageModel =
            await _mediator.Send(new GetCatalogsQuery()
            {
                Pagination = pagination
            });
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CatalogDto Catalog)
    {
        if(ModelState.IsValid is false)
        {
            return View(Catalog);
        }
        await _mediator.Send(new InsertCatalogCommand()
        {
            Catalog = Catalog
        });
        return Redirect("/Admin/Catalog");
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        CatalogDto Catalog = await _mediator.Send
            (new GetCatalogQuery()
            {
                Id = Id
            });
        return View(Catalog);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(CatalogDto Catalog)
    {
        if (ModelState.IsValid is false)
        {
            return View(Catalog);
        }
        await _mediator.Send(new UpdateCatalogCommand()
        {
            Catalog = Catalog
        });
        return Redirect("/Admin/Catalog");
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteCatalogCommand()
            {
                Id = input.Id
            });
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
                ex.Message,
            });
        }
    }








}
