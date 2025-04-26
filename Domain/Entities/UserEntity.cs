using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UserEntity : IdentityUser<Guid>, IDelete
{
    public string? Avatar {  get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }   
    public bool IsDeleted { get ; set ; }=false;
}
