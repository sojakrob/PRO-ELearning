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
            return ButtonLink(helper, linkText, actionName, null, null, null);
        }
        public static IHtmlString ButtonLink(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            return ButtonLink(helper, linkText, actionName, controllerName, null, null);
        }
        public static IHtmlString ButtonLink(this HtmlHelper helper, string linkText, string actionName, object routeValues)
        {
            return ButtonLink(helper, linkText, actionName, null, routeValues, null);
        }
        public static IHtmlString ButtonLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, object routeValues, string target)
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

            if (target != null)
                builder.MergeAttribute("target", target);

            builder.InnerHtml = linkText;
            builder.AddCssClass("button");

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
            
        }

        public static IHtmlString ButtonJSClick(this HtmlHelper helper, string title, string text, string jsCode)
        {
            UrlHelper url = new UrlHelper(helper.ViewContext.RequestContext);

            TagBuilder builder = new TagBuilder("input");
            builder.AddCssClass("Button");
            builder.MergeAttribute("type", "button");
            builder.MergeAttribute("title", title);
            builder.MergeAttribute("value", text);
            builder.MergeAttribute("onclick", jsCode);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static IHtmlString TextInput(this HtmlHelper helper, string idName, string value, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("input");
            builder.MergeAttribute("type", "text");
            builder.MergeAttribute("id", idName);
            builder.MergeAttribute("name", idName);
            builder.MergeAttribute("value", value);
            foreach (KeyValuePair<string, object> htmlAttribute in htmlAttributes)
                builder.MergeAttribute(htmlAttribute.Key, htmlAttribute.Value.ToString());

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
        public static IHtmlString Radio(this HtmlHelper helper, string id, string name, string value, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("input");
            builder.MergeAttribute("type", "radio");
            builder.MergeAttribute("id", id);
            builder.MergeAttribute("name", name);
            builder.MergeAttribute("value", value);
            foreach (KeyValuePair<string, object> htmlAttribute in htmlAttributes)
                builder.MergeAttribute(htmlAttribute.Key, htmlAttribute.Value.ToString());

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}