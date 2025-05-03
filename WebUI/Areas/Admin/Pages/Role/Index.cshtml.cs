using Application.Commands.Role;
using Application.Common;
using Application.Common.Resource;
using Application.Queries.Role;
using Application.Queries.Role.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Security.Claims;
using WebUI.Model;

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
    public async Task<JsonResult> OnPostDeleteAsync([FromBody]InputModel input)
    {
        try
        {
            // تبدیل ورودی به مدل مناسب
            //var id = Convert.ToInt32(input?.GetType().GetProperty("Id")?.GetValue(input));

            //await _mediator.Send(new DeleteRoleCommand(id));

            return new JsonResult(true);
        }
        catch (Exception ex)
        {
            return new JsonResult(new
            {
                IsSuccess = false,
                Message = $"خطا در test درخواست: {ex.Message}"
            });
        }
    }


}
