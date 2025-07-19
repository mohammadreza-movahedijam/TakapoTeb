using Application.Commands.Partner;
using Application.Commands.Product;
using Application.Queries.Partner;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;

[AdminAuthorize("Partner")]
[Area("Admin")]
public class PartnerController (IMediator mediator): Controller
{
    readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<PartnerViewModel> pageModel =
            await _mediator.Send(new GetPartnersQuery(pagination));
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PartnerDto Partner)
    {
        if(Partner.File is null)
        {
            ViewBag.ErrorMessage = "لوگو را آپلود کنید";
            return View(Partner);
        }
        await _mediator.Send(new IndertPartnerCommand(Partner));
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        PartnerDto Partner = await _mediator.Send(new GetPartnerQuery(Id));
        return View(Partner);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(PartnerDto Partner)
    {
        await _mediator.Send(new UpdatePartnerCommand(Partner));
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeletePartnerCommand(input.Id));
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
