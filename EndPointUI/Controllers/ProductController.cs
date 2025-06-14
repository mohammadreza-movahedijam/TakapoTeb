using Application.Queries.ProductCategory.ViewModels;
using Application.Queries.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Queries.Product.ViewModels;
using Application.Queries.Product;

namespace EndPointUI.Controllers;

public class ProductController (IMediator mediator): Controller
{
    readonly IMediator _mediator = mediator;
    public async Task<IActionResult> ProductCategory(List<Guid> patterns,Pagination pagination)
    {
        ViewBag.Pattern=patterns;
       
        PaginatedList<ProductViewModel>
            model = await _mediator.Send(new GetProductByCategoryIdQuery()
            {
                Pagination = pagination,
                CategoryIds = patterns
            });
        return View(model);
    }
    public async Task<IActionResult> Detail(Guid pattern)
    {
        ProductDetailViewModel model =
            await _mediator.Send(new GetProductDetailQuery()
            {
                Id = pattern,
            });
        return View(model);
    }


}
