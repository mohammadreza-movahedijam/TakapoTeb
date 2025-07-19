using Application.Commands.Option;
using Application.Commands.TreatmentCenter;
using Application.Queries.Option;
using Application.Queries.TreatmentCenter;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;

[AdminAuthorize("TreatmentCenter")]
[Area("Admin")]
public class TreatmentCenterController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination, Guid ProductId)
    {
        ViewBag.ProductId = ProductId;
        PaginatedList<TreatmentCenterViewModel> pageModel =
            await _mediator.Send(new GetTreatmentCentersQuery()
            {
                Pagination = pagination,
                ProductId = ProductId
            });
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
    public async Task<IActionResult> Create(TreatmentCenterDto treatmentCenter)
    {
        if (ModelState.IsValid is false)
        {
            ViewBag.ProductId = treatmentCenter.ProductId;

            return View(treatmentCenter);
        }
        await _mediator.Send(new InsertTreatmentCenterCommand()
        {
            TreatmentCenter= treatmentCenter
        });
        return RedirectToAction(nameof(Index), new { ProductId = treatmentCenter.ProductId });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {

        TreatmentCenterDto TreatmentCenter = await _mediator.Send(new GetTreatmentCenterQuery()
        {
            Id= Id
        });
        return View(TreatmentCenter);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(TreatmentCenterDto treatmentCenter)
    {
        if (ModelState.IsValid is false)
        {
            ViewBag.ProductId = treatmentCenter.ProductId;

            return View(treatmentCenter);
        }
        await _mediator.Send(new UpdateTreatmentCenterCommand()
        {
            TreatmentCenter=treatmentCenter
        });
        return RedirectToAction(nameof(Index), new { ProductId = treatmentCenter.ProductId });
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteTreatmentCenterCommand()
            {
                Id  = input.Id
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
                Message = ex.Message,
            });
        }
    }
}
