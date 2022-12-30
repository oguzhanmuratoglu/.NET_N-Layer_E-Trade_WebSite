using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Mrt.Northwind.MvcWepUI.TagHalpers
{
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHalper:TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }

        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }

        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }

        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<nav aria-label='...'>");
            stringBuilder.AppendFormat("<ul class='pagination'>");

            for (int i = 1; i <= PageCount; i++)
            {
                stringBuilder.AppendFormat("<li class='{0}'>", i==CurrentPage ? "page-item active" : "page-item");
                stringBuilder.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}'>{2}</a>", i,CurrentCategory,i);
                stringBuilder.AppendFormat("</li>");
            }

            stringBuilder.AppendFormat("</ul>");
            stringBuilder.Append("</nav>");

            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }
    }
}
