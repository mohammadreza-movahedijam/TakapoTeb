using Application.Commands.Role;
using Application.Commands.Role.DataTransferObject;
using Application.Common.CustomException;
using Application.Queries.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Areas.Admin.Pages.Role;

public class EditModel (IMediator mediator): PageModel
{
    readonly IMediator _mediator=mediator;
    [BindProperty]
    public RoleDto Role { get; set; }
    public string Message { get; set; } = string.Empty;

    public async Task OnGetAsync(Guid Id)
    {
        Role = await _mediator.Send(new GetRoleQuery(Id)); 
    }
    public async Task<IActionResult> OnPostAsync(RoleDto role)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _mediator.Send(new UpdateRoleCommand(role));
            return RedirectToPage("Index");
        }
        catch (InternalException ex)
        {
            Message = ex.Message;
            return Page();

        }

    }
}
