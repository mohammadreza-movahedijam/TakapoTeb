using Application.Common;
using Application.Queries.Role;
using Application.Queries.Role.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Areas.Admin.Pages.Role;

public class IndexModel(IMediator mediator) : PageModel
{
  
    readonly IMediator _mediator = mediator;
    public PaginatedList<RoleViewModel> PageModel { get; set; }
    public async Task OnGet([FromQuery] Pagination pagination)
    {
        if (!string.IsNullOrEmpty(pagination.keyword))
        {
            ViewData["Search"] = pagination.keyword;
        }
        PageModel = await _mediator.Send(new GetRolesQuery(pagination));
    }
}
