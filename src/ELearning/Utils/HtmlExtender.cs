using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELearning.Utils
{
    public static class HtmlExtender
    {
        public static IHtmlString ButtonLink(this HtmlHelper helper, string linkText, string actionName)
        {
            return ButtonLink(helper, linkText, actionName, null, null);
        }
        public static IHtmlString ButtonLink(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            return ButtonLink(helper, linkText, actionName, controllerName, null);
        }
        public static IHtmlString ButtonLink(this HtmlHelper helper, string linkText, string actionName, object routeValues)
        {
            return ButtonLink(helper, linkText, actionName, null, routeValues);
        }
        public static IHtmlString ButtonLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, object routeValues)
        {
            UrlHelper url = new UrlHelper(helper.ViewContext.RequestContext);

            TagBuilder builder = new TagBuilder("a");

            if (controllerName == null)
            {
                if (routeValues == null)
                    builder.MergeAttribute("href", url.Action(actionName));
                else
                    builder.MergeAttribute("href", url.Action(actionName, routeValues));
            }
            else
            {
                if (routeValues == null)
                    builder.MergeAttribute("href", url.Action(actionName, controllerName));
                else
                    builder.MergeAttribute("href", url.Action(actionName, controllerName, routeValues));
            }

            builder.InnerHtml = linkText;
            builder.AddCssClass("button");

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
            
        }
    }
}