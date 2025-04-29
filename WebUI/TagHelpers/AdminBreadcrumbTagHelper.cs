
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.TagHelpers;
[HtmlTargetElement("adminbreadcrumb")]
public class AdminBreadcrumbTagHelper : TagHelper
{
    public List<BreadcrumbItem> Items { get; set; } = new List<BreadcrumbItem>();

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "nav";
        output.Attributes.SetAttribute("aria-label", "breadcrumb");

        var content =  RenderContent();

        output.Content.AppendHtml(content);
    }

    private string RenderContent()
    {
        var html = $@"
            <ol class=""lh-1-85 breadcrumb"">
                {string.Join("\n", Items.Select(item => GenerateBreadcrumbItem(item)))}
            </ol>
        ";
        return html;
    }

    private string GenerateBreadcrumbItem(BreadcrumbItem item)
    {
        if (item.IsActive)
        {
            return $@"
                <li  class=""breadcrumb-item active"">{item.Text}</li>
            ";
        }
        return $@"
            <li class=""breadcrumb-item"">
                <a href=""/{item.Area}/{item.Folder}/{item.Page}"">{item.Text}</a>
            </li>
        ";
    }
}

public class BreadcrumbItem
{
    public string? Area { get; set; }
    public string? Folder { get; set; }
    public string? Page { get; set; }

    public string? Text { get; set; }
    public bool IsActive { get; set; }
}