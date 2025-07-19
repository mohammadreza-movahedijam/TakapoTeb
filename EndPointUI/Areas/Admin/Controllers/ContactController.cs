using Application.Commands.Message;
using Application.Queries.Message;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;


[Area("Admin")]
[AdminAuthorize("Contact")]
public class ContactController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    public async Task<IActionResult> Index(Pagination pagination)
    {
        PaginatedList<MessageViewModel> pageModel =
          await _mediator.Send(new GetMessagesQuery()
          {
              Pagination = pagination
          });
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteMessageCommand()
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
