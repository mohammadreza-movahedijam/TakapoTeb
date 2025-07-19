using Application.Commands.Document;
using Application.Queries.Document;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("Document")]
public class DocumentController (IMediator mediator) : Controller
{
    readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination, Guid ProductId)
    {
        ViewBag.ProductId = ProductId;
        PaginatedList<DocumentViewModel> pageModel =
            await _mediator.Send(new GetDocumentsQuery( ProductId, pagination));
        ViewBag.Search = pagination.keyword;
        return View(pageModel);
    }
    [HttpGet]
    public async Task<IActionResult> Create(Guid ProductId)
    {
        ViewBag.ProductId = ProductId;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(DocumentDto ProductDocument)
    {
        if (ModelState.IsValid is false)
        {
            ViewBag.ProductId = ProductDocument.ProductId;

            return View(ProductDocument);
        }
        await _mediator.Send(new InsertDocumentCommand(ProductDocument));
        return RedirectToAction(nameof(Index), new { ProductId = ProductDocument.ProductId });
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteDocumentCommand(input.Id));
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
}
