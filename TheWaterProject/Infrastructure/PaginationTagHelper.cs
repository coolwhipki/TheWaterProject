using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Infrastructure
{   
    //where we are going to see this feature is in the div tag
    //how we are going to access this helper is when we call page-model
    [HtmlTargetElement("div", Attributes = "page-model")]

    public class PaginationTagHelper : TagHelper
    {
        //use this to build url
        private IUrlHelperFactory urlHelperFactory;

        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            this.urlHelperFactory = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound] //we don't want users to say viewcontext in the tag (not bound to the html tag)
        public ViewContext? ViewContext { get; set; }

        public string? PageAction { get; set; } // capitalization (asp.net does the translation)
        public PaginationInfo PageModel { get; set; }

        //build our tag

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlhelper = urlHelperFactory.GetUrlHelper(ViewContext);

                TagBuilder result = new TagBuilder("div");

                for (int i = 1; i <= PageModel.TotalPages; i++) 
                { 
                    TagBuilder tag = new TagBuilder("a");

                    tag.Attributes["href"] = urlhelper.Action(PageAction, new {pageNum = i});
                    tag.InnerHtml.Append(i.ToString());

                    result.InnerHtml.AppendHtml(tag);

                }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
