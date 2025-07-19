using Application.Common;
using Application.Queries.Role.ViewModel;
using Application.Queries.Role;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.Role.DataTransferObject;
using Application.Commands.Role;
using EndPointUI.Areas.Admin.Models;

namespace EndPointUI.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("Role")]
public class RoleController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<RoleViewModel> pageModel = 
            await _mediator.Send(new GetRolesQuery(pagination));
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create( RoleDto role)
    {
        await _mediator.Send(new InsertRoleCommand(role));
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        RoleDto Role=await _mediator.Send(new GetRoleQuery(Id));
        return View(Role);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(RoleDto role)
    {
        await _mediator.Send(new UpdateRoleCommand(role));
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody]InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteRoleCommand(input.Id));
            return new JsonResult(new
            {
                IsSuccess = true,
                Message = string.Empty,
            });
        }
        catch(Exception ex) 
        {
            return new JsonResult(new
            {
                IsSuccess = false,
                Message = ex.Message,
            });
        }
    }


    [HttpGet]
    public async Task<IActionResult> RouteAccess(Guid Id)
    {
        await FetchRouts(Id);
        ViewBag.Id = Id;
        return View();

    }
    [HttpPost]

    public async Task<IActionResult> RouteAccess(RoleRouteDto model)
    {

        await _mediator.Send(new SetRouteCommand()
        {
            RoleRoute = model
        });
        return RedirectToAction(nameof(Index));
    }
    async Task FetchRouts(Guid Id)
    {
        var model = await _mediator.Send(new GetRoleRoutesQuery()
        {
            RoleId = Id
        });
        ViewBag.Data = model;
    }
}
