using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Setting;

public sealed record ChangeSettingCommand:
    IRequest
{
    public SettingDto Setting {  get; set; }
    public ChangeSettingCommand(SettingDto Setting)
    {
        this.Setting = Setting;
    }
}
