using System.ComponentModel.DataAnnotations;

namespace Application.Commands.User.DataTransferObject;

public sealed record SignUpDto
{

    [Required(ErrorMessageResourceName = "RequiredUserName",
        ErrorMessageResourceType = typeof(ValidationMessages))]
    public string? UserName { get; set; }

    [Required(ErrorMessageResourceName = "RequiredPassword",
     ErrorMessageResourceType = typeof(ValidationMessages))]
    public string? Password { get; set; }

    [Required(ErrorMessageResourceName = "RequiredEmail",
     ErrorMessageResourceType = typeof(ValidationMessages))]
    public string? Email { get; set; }

    [Required(ErrorMessageResourceName = "RequiredPhoneNumber",
     ErrorMessageResourceType = typeof(ValidationMessages))]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessageResourceName = "RequiredFirstName",
     ErrorMessageResourceType = typeof(ValidationMessages))]
    public string? FirstName { get; set; }

    [Required(ErrorMessageResourceName = "RequiredLastName",
     ErrorMessageResourceType = typeof(ValidationMessages))]
    public string? LastName { get; set; }
}
