namespace Application.Queries.User.ViewModel;

public sealed record UserViewModel
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { set; get; }
    public string? UserName { set; get; }
}
