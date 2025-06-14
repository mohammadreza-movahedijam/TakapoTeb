using System.ComponentModel.DataAnnotations;

namespace Application.Commands.User.DataTransferObject;

public sealed record SignInDto
{
    [Required(ErrorMessageResourceName = "RequiredUserName",
     ErrorMessageResourceType = typeof(ValidationMessages))]
    public string? UserName { get; set; }

    [Required(ErrorMessageResourceName = "RequiredPassword",
     ErrorMessageResourceType = typeof(ValidationMessages))]
    public string? Password { get; set; }
}
