using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ProductCategory.ViewModels;

public sealed record CategoryMenuViewModel
{
    public Guid Id { get; set; }
    public Guid? ParentProductCategoryId { get; set; }
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
    public int DisplayPriority { get; set; }
    public List<CategoryMenuViewModel>? SubCategories { get; set; } = [];
}
