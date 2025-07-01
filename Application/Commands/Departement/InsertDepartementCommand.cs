using MediatR;

namespace Application.Commands.Departement;

public sealed record InsertDepartementCommand : IRequest
{
    public DepartementDto? Departement { get; set; }
}
