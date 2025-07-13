using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Search;

public sealed record SearchViewModel
{
    public Guid Id { get; set; }  
    
    public string? Image { get; set; }
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public int flag {  get; set; }  
}
