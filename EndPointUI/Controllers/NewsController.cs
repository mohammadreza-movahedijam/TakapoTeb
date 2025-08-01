using Application.Queries.Article.ViewModels;
using Application.Queries.Article;
using Application.Queries.News;
using Domain.Types;
using EndPointUI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Controllers;

public class NewsController (IMediator mediator): Controller
{
    readonly IMediator _mediator=mediator;
    [HttpGet]
    [Route("News")]
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpPost]
    [Route("GetNews")]
    public async Task<IActionResult> GetNews([FromBody] NewsModel model)
    {
        int part = 0;
        var news = await _mediator.Send(new GetNewsByTopicQuery()
        {
            part = part + model.part,
            NewsCategoryId = model.type
        });

        return new JsonResult(new
        {
            IsSuccess = true,
            Data = news.Item1,
            Count= news.Item3,
            Current = news.Item2,
        });
    }
    [HttpGet]
    public async Task<IActionResult> Detail(Guid Id)
    {
        NewsDetailViewModel model =
            await _mediator.Send(new GetNewsDetailQuery()
            {
                Id = Id
            });
        return View(model);
    }

}
