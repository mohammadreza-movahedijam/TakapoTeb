using Application.Notification.Request;
using Application.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;
[Area("Admin")]
public class RequestController (IMediator mediator): Controller
{
    readonly IMediator _mediator=mediator;
    [HttpGet]
    public async Task<IActionResult> Service
        ([FromQuery] Pagination pagination)
    {
        PaginatedList<RequestViewModel> paginated
            = await _mediator.Send(new GetRequestServicesQuery()
            {
                Pagination = pagination
            });
        ViewBag.Search=pagination.keyword;
        return View(paginated);
    }
    [HttpGet]
    public async Task<IActionResult> ServiceDetail(Guid id)
    {

        await _mediator.Publish(new UpdateSeenRequestNotification()
        {
            Id = id,
            IsService = true
        });
        RequestServiceDetailViewModel detail =
            await _mediator.Send(new GetRequestServiceQuery()
            {
                Id = id,
            });
        return View(detail);
    }

    [HttpGet]
    public async Task<IActionResult> Education
       ([FromQuery] Pagination pagination)
    {
        PaginatedList<RequestViewModel> paginated
            = await _mediator.Send(new GetRequestEducationsQuery()
            {
                Pagination = pagination
            });
        ViewBag.Search = pagination.keyword;
        return View(paginated);
    }
    [HttpGet]
    public async Task<IActionResult> EducationDetail(Guid id)
    {
        await _mediator.Publish(new UpdateSeenRequestNotification()
        {
            Id = id,
            IsService = false
        });
        RequestEducationDetailViewModel detail =
            await _mediator.Send(new GetRequestEducationQuery()
            {
                Id = id,
            });
        return View(detail);
    }
}
