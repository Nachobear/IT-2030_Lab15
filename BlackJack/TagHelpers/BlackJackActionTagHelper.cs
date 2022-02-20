using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Razor.Runtime;

namespace BlackJack.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    
    public class MyBlackJackActionTagHelper : TagHelper
    {
        private LinkGenerator linkBuilder;

        public MyBlackJackActionTagHelper(LinkGenerator lg) => this.linkBuilder = lg;

        [ViewContext]
        [HtmlAttributeNotBoundAttribute]
        public ViewContext ViewCtx { get; set; }

        public string Action { get; set; }

        public bool IsDisabled { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "form";
            output.TagMode = TagMode.StartTagAndEndTag;

            string controller = ViewCtx.RouteData.Values["controller"].ToString();
            string url = linkBuilder.GetPathByAction(this.Action, controller);

            output.Attributes.SetAttribute("action", url);
            output.Attributes.SetAttribute("method", "post");
            output.Attributes.SetAttribute("class", "col");

            TagBuilder button = new TagBuilder("button");
            button.Attributes.Add("type", "submit");
            button.Attributes.Add("class", "btn btn-primary");
            button.InnerHtml.Append(this.Action);

            if (this.IsDisabled)
            {
                button.Attributes.Add("disabled", "disabled");
            }

            output.Content.AppendHtml(button);


        }
    }
}
