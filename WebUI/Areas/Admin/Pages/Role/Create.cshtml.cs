using Application.Commands.Role.DataTransferObject;
using Application.Commands.Role;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.Common.CustomException;

namespace WebUI.Areas.Admin.Pages.Role;

public class CreateModel (IMediator mediator): PageModel
{
    readonly IMediator _mediator= mediator;
    [BindProperty]
    public RoleDto Role { get; set; }
    public string Message { get; set; } =string.Empty;
    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPostAsync(RoleDto role)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _mediator.Send(new InsertRoleCommand(role));
            return RedirectToPage("Index");
        }
        catch (InternalException ex)
        {
            Message = ex.Message;
            return Page();

        }

    }
}
