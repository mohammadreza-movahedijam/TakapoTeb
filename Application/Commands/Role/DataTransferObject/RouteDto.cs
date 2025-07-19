using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Role.DataTransferObject;

public sealed record RouteDto
{
    public string? Title {  get; set; }
    public Guid Id { get; set; }
}
public sealed record RoleRouteDto
{
    public List<Guid>? Routes { get; set; } = new();
    public Guid RoleId { get; set; }
}
