using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity;

public class RoleEntity : IdentityRole<Guid>,IDelete
{
    public string? PersianName { get; set; }
    public bool IsDefault {  get; set; } = false;
    public bool IsDeleted { get ; set ; }=false;
}
