using Application.Commands.Option;
using Application.Queries.Option;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Option")]
public class OptionController
    (IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination, Guid ProductId)
    {
        ViewBag.ProductId = ProductId;
        PaginatedList<OptionViewModel> pageModel =
            await _mediator.Send(new GetOptionsQuery(ProductId, pagination));
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpGet]
    public async Task<IActionResult> Create(Guid ProductId)
    {
        ViewBag.ProductId = ProductId;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(OptionDto ProductOption)
    {
        if (ModelState.IsValid is false)
        {
            ViewBag.ProductId = ProductOption.ProductId;

            return View(ProductOption);
        }
        await _mediator.Send(new InsertOptionCommand(ProductOption));
        return RedirectToAction(nameof(Index), new { ProductId = ProductOption.ProductId });
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {

        OptionDto ProductOption = await _mediator.Send(new GetOptionQuery(Id));
        return View(ProductOption);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(OptionDto ProductOption)
    {
        if (ModelState.IsValid is false)
        {
            ViewBag.ProductId = ProductOption.ProductId;

            return View(ProductOption);
        }
        await _mediator.Send(new UpdateOptionCommand(ProductOption));
        return RedirectToAction(nameof(Index), new { ProductId = ProductOption.ProductId });
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteOptionCommand(input.Id));
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

}

