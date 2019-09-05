using Store.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace Store.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            TagBuilder pagination = new TagBuilder("ul");

            pagination.AddCssClass("pagination");

            string link = "";

            if (pagingInfo.CurrentPage != 1)
                link = CreateLink("Previous", pageUrl, pagingInfo.CurrentPage - 1);

            pagination.InnerHtml += link;

            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                link = "";
                if (i == pagingInfo.CurrentPage)
                    link = CreateLink(i.ToString(), pageUrl, i, true);
                else
                    link = CreateLink(i.ToString(), pageUrl, i);

                pagination.InnerHtml += link;
            }

            link = "";

            if (pagingInfo.CurrentPage != pagingInfo.TotalPages)
                link = CreateLink("Next", pageUrl, pagingInfo.CurrentPage + 1);

            pagination.InnerHtml += link;

            result.Append(pagination.ToString());

            return MvcHtmlString.Create(result.ToString());
        }

        private static string CreateLink(string text, Func<int, string> pageUrl, int number, bool active = false)
        {
            TagBuilder li = new TagBuilder("li");
            TagBuilder a = new TagBuilder("a");

            li.AddCssClass("page-item");

            a.MergeAttribute("href", pageUrl(number));

            a.InnerHtml = text;
            a.AddCssClass("page-link");

            if (active)
            {
                a.AddCssClass("selected");
                a.AddCssClass("btn-primary");
            }

            li.InnerHtml += a.ToString();

            return li.ToString();
        }
    }
    
}