using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Product;

public sealed record DeleteProductCommand:IRequest
{
    public Guid Id { get; set; }
    public DeleteProductCommand(in Guid Id)
    {
        this.Id = Id;
    }
}
