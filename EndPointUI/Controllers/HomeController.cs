using Application.Commands.Message;
using Application.Queries.Partner;
using Application.Queries.Search;
using Application.Queries.Setting;
using Application.Queries.Setting.ViewModels;
using Application.Queries.TreatmentCenter;
using EndPointUI.Areas.Admin.Models;
using EndPointUI.Models;
using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EndPointUI.Controllers;

public class HomeController : Controller
{
    readonly IMediator? _mediator;
    public HomeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    [Route("TreatmentCenter")]
    public async Task<IActionResult> TreatmentCenter()
    {
        IReadOnlyList<TreatmentCenterViewModel>
            pageModel=await _mediator!.Send(new GetTreatmentCenterProductsQuery());
        return View(pageModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [Route("ContactUs")]
    public async Task<IActionResult> ContactUs()
    {
        ContactUsViewModel? contactUs =
            await _mediator.Send(new GetContactInfoQuery());
        return View(contactUs);
    }

    [HttpPost]
    [Route("AddMessage")]
    public async Task<IActionResult> AddMessage([FromBody]MessageDto message)
    {


        await _mediator.Send(new InsertMessageCommand()
        {
            Message = message
        });
        return new JsonResult(new
        {
            IsSuccess = true,
            Message = string.Empty,
        });
    }

    public IActionResult ChangeLanguage(string culture)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );
        return Redirect(Request.Headers["Referer"].ToString());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    [HttpGet]
    [Route("Search")]
    public async Task<IActionResult> Search(string text)
    {
        ViewBag.Search = text;
        IReadOnlyList<SearchViewModel> pageModel =await
            _mediator.Send(new GetListWithKeywordQuery()
            {
                Search = text
            });
        return View(pageModel);
    }
    [HttpGet][Route("/404")]
    public IActionResult NotFound()
    {
        return View();
    }
    [HttpGet][Route("/Forbidden")]
    public IActionResult Forbidden()
    {
        return View();
    }

    [HttpGet]
    [Route("/Partner/{Id}")]
    public async Task<IActionResult> Partner(Guid Id)
    {
        PartnerDetailViewModel partnerDetail=
            await _mediator.Send(new GetPartnerDetailQuery()
            {
                Id=Id
            });
        return View(partnerDetail);
    }





    [HttpGet]
    [Route("Request-Education")]
    public IActionResult RequestEducation() => View();


    [Route("Request-Service")]
    [HttpGet]
    public IActionResult RequestService() => View();
  
}
