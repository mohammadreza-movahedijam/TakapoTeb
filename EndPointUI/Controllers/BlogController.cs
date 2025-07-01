using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Controllers;

public class BlogController (IMediator mediator): Controller
{
    readonly IMediator _mediator=mediator;
    public IActionResult Index()
    {
        return View();
    }
}
