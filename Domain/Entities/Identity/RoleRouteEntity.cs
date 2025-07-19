using Domain.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity;

[Table("RoleRouteMap",Schema ="dbo")]
public class RoleRouteEntity:BaseEntity
{
    public Guid RoleId { get; set; }
    [ForeignKey("RoleId")]
    public RoleEntity? Role { get; set; }


    public Guid RouteId { get; set; }
    [ForeignKey("RouteId")]
    public RouteEntity? Route { get; set; }

}
