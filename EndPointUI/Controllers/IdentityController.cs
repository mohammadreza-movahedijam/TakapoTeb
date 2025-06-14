using Application.Commands.User;
using Application.Commands.User.DataTransferObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Controllers;

public class IdentityController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    [Route("SignIn")]
    [HttpGet]
    public async Task<IActionResult> SignIn()
    {
        if (User.Identity!.IsAuthenticated)
        {
            return Redirect("/");
        }
        ViewBag.Error = null;
        return View();
    }

    [Route("SignIn")]
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInDto signIn)
    {
        if (ModelState.IsValid)
        {
            BaseResult result = await _mediator.Send(new SignInCommand()
            {
                SignIn = signIn
            });

            if (result.IsSuccess is false)
            {
                ViewBag.Error = result.Message;
                return View(signIn);
            }
            return Redirect("/User/Dashboard/MyProfile");
        }
        return View();
    }


    [Route("SignUp")]
    [HttpGet]
    public async Task<IActionResult> SignUp()
    {
        if (User.Identity!.IsAuthenticated)
        {
            return Redirect("/");
        }
        ViewBag.Error = null;
        return View();
    }
    [Route("SignUp")]
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpDto signUp)
    {
        if (ModelState.IsValid)
        {
            BaseResult result = await _mediator.Send(new SignUpCommand()
            {
                SignUp = signUp
            });

            if (result.IsSuccess is false)
            {
                ViewBag.Error = result.Message;
                return View(signUp);
            }
            return Redirect("/");
        }
        return View();
    }
    [Route("SignOut")]
    public async Task<IActionResult> SignOut()
    {
        if (User.Identity!.IsAuthenticated)
        {
            await _mediator.Send(new SignOutCommand());
        }
        return Redirect("/");
    }
}
