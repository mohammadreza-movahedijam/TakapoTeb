using Application.Commands.Departement;
using Application.Queries.Departement;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("Departement")]
public class DepartementController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<DepartementViewModel> pageModel =
            await _mediator.Send(new GetDepartementsQuery()
            {
                Pagination=pagination   
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
    public async Task<IActionResult> Create(DepartementDto Departement)
    {
        await _mediator.Send(new InsertDepartementCommand()
        {
            Departement= Departement
        });
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        DepartementDto Departement = await _mediator.Send
            (new GetDepartementQuery()
            {
                Id=Id
            });
        return View(Departement);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(DepartementDto Departement)
    {
        await _mediator.Send(new UpdateDepartementCommand()
        {
                Departement=Departement
        });
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteDepartementCommand()
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
