using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BlackJack.TagHelpers
{
    public static class TagHelperExtensions
    {
        public static void AppendCssClass(this TagHelperAttributeList list, string newCssClassess)
        {
            string existingCssClasses = list["class"]?.Value?.ToString();

            string cssClasses = string.IsNullOrEmpty(existingCssClasses)
                ? newCssClassess : $"{existingCssClasses} {newCssClassess}";

            list.SetAttribute("class", cssClasses);
        }
        public static void BuildTag(this TagHelperOutput output, string tagName, string classNames)
        {
            output.TagName = tagName;
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.AppendCssClass(classNames);
        }
    }
}
