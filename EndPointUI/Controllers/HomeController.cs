using Application.Commands.Message;
using Application.Commands.RequestEducation;
using Application.Commands.RequestService;
using Application.Queries.Catalog;
using Application.Queries.Event;
using Application.Queries.Page;
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

    [HttpGet]
    [Route("/About")]
    public async Task<IActionResult> About()
    {
        AboutViewModel model =
            await _mediator!.Send(new GetAboutPageQuery());
        return View(model);
    }





    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    [Route("Media")]
    public async Task<IActionResult> Media()
    {
        IReadOnlyList<EventDetailViewModel> model = await _mediator!
            .Send(new GetEventsDetailQuery());
        return View(model);
    }











    [HttpGet]
    [Route("Page")]
    public async Task<IActionResult> Page(Guid Id)
    {
        PageDetailViewModel pageDetail=
            await _mediator!.Send(new GetPageDetailQuery()
            {
                Id=Id
            });
        return View(pageDetail);
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
    public async Task<IActionResult> Book()
    {
        IReadOnlyList<CatalogDetailViewModel>
            model = await _mediator!.Send
            (new GetBookOrCatalogQuery()
            {
                Type=Domain.Types.FileType.Book,
            });
        return View(model);
    }
    [HttpGet]
    public async Task<IActionResult> Catalog()
    {
        IReadOnlyList<CatalogDetailViewModel>
            model = await _mediator!.Send
            (new GetBookOrCatalogQuery()
            {
                Type = Domain.Types.FileType.Catalog,
            });
        return View(model);
    }
    [HttpGet]
    [Route("Request-Education")]
    public IActionResult RequestEducation() => View();
    [Route("Request-Service")]
    [HttpGet]
    public IActionResult RequestService() => View();
    [HttpPost]
    [Route("SendRequestEducation")]
    public async Task<IActionResult> SendRequestEducation
        (RequestEducationDto requestEducation)
    {
        try
        {
            await _mediator!.Send(new InsertRequestEducationCommand(){
                RequestEducation= requestEducation
            });
            return new JsonResult(new
            {
                IsSuccess = true
            });

        }
        catch (Exception ex) 
        {
            return new JsonResult(new
            {
                IsSuccess=false
            });
        }
    }
    [HttpPost]
    [Route("SendRequestService")]
    public async Task<IActionResult> SendRequestService
       (RequestServiceDto requestService)
    {
        try
        {
            await _mediator!.Send(new InsertRequestServiceCommand()
            {
                RequestService = requestService
            });
            return new JsonResult(new
            {
                IsSuccess = true
            });

        }
        catch (Exception ex)
        {
            return new JsonResult(new
            {
                IsSuccess = false
            });
        }
    }

}
