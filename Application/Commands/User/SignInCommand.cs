using Application.Commands.User.DataTransferObject;
using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User;

public sealed record SignInCommand:IRequest<BaseResult>
{
    public SignInDto? SignIn {  get; set; }
}
