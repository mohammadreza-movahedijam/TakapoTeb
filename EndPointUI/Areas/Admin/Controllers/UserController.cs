using Application.Commands.Role;
using Application.Commands.User;
using Application.Commands.User.DataTransferObject;
using Application.Common.CustomException;
using Application.Queries.Role;
using Application.Queries.User;
using Application.Queries.User.ViewModel;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPointUI.Areas.Admin.Controllers;

[Area("Admin")]
public class UserController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    public async Task<IActionResult> Index(Pagination pagination)
    {
        PaginatedList<UserViewModel>
            pageModel = await _mediator.Send(new GetUsersQuery(pagination));
        return View(pageModel);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.ErrorMessage = null;
       await FetchRole();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(UserDto user)
    {
        try
        {
            if (ModelState.IsValid is false)
            {
                await FetchRole(user.Role);
                return View(user);
            }
            await _mediator.Send(new InsertUserCommand(user));
            return RedirectToAction(nameof(Index));
        }
        catch (InternalException ex) 
        {
            ViewBag.ErrorMessage = ex.Message;
            await FetchRole(user.Role);
            return View(user);

        }
    }

    [HttpGet]
    public async Task<IActionResult>Edit(Guid Id)
    {
        UserDto user=await _mediator.Send(new GetUserQuery(Id));
        await FetchRole(user.Role);
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserDto user)
    {
        try
        {
            if (ModelState.IsValid is false)
            {
                await FetchRole(user.Role);
                return View(user);
            }
            await _mediator.Send(new UpdateUserCommand(user));
            return RedirectToAction(nameof(Index));
        }
        catch (InternalException ex)
        {
            ViewBag.ErrorMessage = ex.Message;
            await FetchRole(user.Role);
            return View(user);

        }
    }



    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteUserCommand(input.Id));
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
    [HttpPost]
    public async Task<IActionResult> SetPassword([FromBody] passwordModel input)
    {
        try
        {
            await _mediator.Send(new SetPasswordCommand()
            {
                Password = input.Password,
                UserId=input.UserId
                
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
    private async Task FetchRole(string? selected=null)
    {
        var roles = await _mediator.Send(new GetRoleItemQuery());
        if (selected is null)
        {
            ViewBag.Roles = new SelectList(roles, "Id", "Title");
        }
        else
        {
            ViewBag.Roles = new SelectList(roles, "Id", "Title", selected);
        }
    }

}
