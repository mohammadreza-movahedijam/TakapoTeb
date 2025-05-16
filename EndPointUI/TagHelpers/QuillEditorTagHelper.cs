using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EndPointUI.TagHelpers
{
    public class QuillEditorTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var modelName = context.AllAttributes["asp-for"].Value.ToString();
            var htmlContent = $@"
            <div class=""quill-container"">
                <input type=""hidden"" id=""{modelName}_Hidden"" name=""{modelName}"" />
                <div id=""{modelName}""></div>
            </div>
            
            <script>
                document.addEventListener('DOMContentLoaded', function() {{
                    var quill = new Quill('#{modelName}', {{
                        theme: 'snow'
                    }});
                    
                    // Set initial content if model has value
                    var hiddenInput = document.getElementById('{modelName}_Hidden');
                    if (hiddenInput.value) {{
                        quill.root.innerHTML = hiddenInput.value;
                    }}
                    
                    // Sync editor content with hidden input
                    quill.on('text-change', function() {{
                        var content = quill.root.innerHTML;
                        hiddenInput.value = content;
                    }});
                }});
            </script>
        ";

            output.Content.Append(htmlContent);
        }
    }
}
