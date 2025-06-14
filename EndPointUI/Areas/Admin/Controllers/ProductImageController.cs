using Application.Commands.Document;
using Application.Commands.Image;
using Application.Queries.Image;
using EndPointUI.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPointUI.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductImageController (IMediator mediator): Controller
{
    readonly IMediator _mediator=mediator;
    public async Task<IActionResult> Index(Guid ProductId)
    {
        ViewBag.ProductId = ProductId;
        IReadOnlyList<ImageViewModel> model = await _mediator.Send(new GetImagesQuery()
        {
            ProductId=ProductId
        });
        return View(model);
    }
    [HttpGet]
    public IActionResult Create(Guid ProductId)
    {
        ViewBag.ProductId = ProductId;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(ImageDto image)
    {
        if (ModelState.IsValid is false)
        {
            ViewBag.ProductId = image.ProductId;

            return View(image);
        }
        await _mediator.Send(new InsertImageCommand(image));
        return RedirectToAction(nameof(Index), 
            new { ProductId = image.ProductId });
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] InputModel input)
    {
        try
        {
            await _mediator.Send(new DeleteImageCommand()
            {
                Id=input.Id
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
}
