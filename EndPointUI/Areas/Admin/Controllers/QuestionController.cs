using Application.Commands.Question;
using Application.Queries.Question;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;


[Area("Admin")]
[AdminAuthorize("Question")]
public class QuestionController(IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<QuestionViewModel> pageModel =
            await _mediator.Send(new GetQuestionsQuery()
            {
                Pagination = pagination
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
    public async Task<IActionResult> Create(QuestionDto Question)
    {
        await _mediator.Send(new InsertQuestionCommand()
        {
            Question = Question
        });
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        QuestionDto Question = await _mediator.Send
            (new GetQuestionQuery()
            {
                Id = Id
            });
        return View(Question);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(QuestionDto Question)
    {
        await _mediator.Send(new UpdateQuestionCommand()
        {
            Question = Question
        });
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteQuestionCommand()
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
