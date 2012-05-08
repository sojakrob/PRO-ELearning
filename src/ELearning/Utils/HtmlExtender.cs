using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Html;

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

        public static IHtmlString LocalizedButtonLink(this HtmlHelper helper, string linkText, string actionName)
        {
            return LocalizedButtonLink(helper, linkText, actionName, null, null, null);
        }
        public static IHtmlString LocalizedButtonLink(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            return LocalizedButtonLink(helper, linkText, actionName, controllerName, null, null);
        }
        public static IHtmlString LocalizedButtonLink(this HtmlHelper helper, string linkText, string actionName, object routeValues)
        {
            return LocalizedButtonLink(helper, linkText, actionName, null, routeValues, null);
        }
        public static IHtmlString LocalizedButtonLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, object routeValues, string target)
        {
            return ButtonLink(helper, Localization.GetResourceString(linkText), actionName, controllerName, routeValues, target);
        }

       
        public static IHtmlString ButtonJSClick(this HtmlHelper helper, string title, string text, string jsCode, object htmlAttrs = null)
        {
            UrlHelper url = new UrlHelper(helper.ViewContext.RequestContext);

            TagBuilder builder = new TagBuilder("input");
            builder.AddCssClass("Button");
            builder.MergeAttribute("type", "button");
            builder.MergeAttribute("title", title);
            builder.MergeAttribute("value", text);
            builder.MergeAttribute("onclick", jsCode);
            if(htmlAttrs != null)
                builder.MergeAttributes(new RouteValueDictionary(htmlAttrs), true);

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
            return Input(helper, "radio", id, name, value, htmlAttributes);
        }
        public static IHtmlString CheckBox(this HtmlHelper helper, string id, string name, string value, IDictionary<string, object> htmlAttributes)
        {
            return Input(helper, "checkbox", id, name, value, htmlAttributes);
        }
        private static IHtmlString Input(this HtmlHelper helper, string type, string id, string name, string value, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("input");
            builder.MergeAttribute("type", type);
            builder.MergeAttribute("id", id);
            builder.MergeAttribute("name", name);
            builder.MergeAttribute("value", value);

            if (htmlAttributes != null)
            {
                foreach (KeyValuePair<string, object> htmlAttribute in htmlAttributes)
                    builder.MergeAttribute(htmlAttribute.Key, htmlAttribute.Value.ToString());
            }

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }


        //
        // Summary:
        //     Returns an anchor element (a element) that contains the virtual path of the
        //     specified action.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action.
        //
        // Returns:
        //     An anchor element (a element).
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        public static MvcHtmlString LocalizedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName)
        {
            return LinkExtensions.ActionLink(htmlHelper, Localization.GetResourceString(linkText), actionName);
        }
        //
        // Summary:
        //     Returns an anchor element (a element) that contains the virtual path of the
        //     specified action.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. The object
        //     is typically created by using object initializer syntax.
        //
        // Returns:
        //     An anchor element (a element).
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        public static MvcHtmlString LocalizedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues)
        {
            return LinkExtensions.ActionLink(htmlHelper, Localization.GetResourceString(linkText), actionName, routeValues);
        }
        //
        // Summary:
        //     Returns an anchor element (a element) that contains the virtual path of the
        //     specified action.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        // Returns:
        //     An anchor element (a element).
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        public static MvcHtmlString LocalizedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues)
        {
            return LinkExtensions.ActionLink(htmlHelper, Localization.GetResourceString(linkText), actionName, routeValues);
        }
        //
        // Summary:
        //     Returns an anchor element (a element) that contains the virtual path of the
        //     specified action.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action.
        //
        //   controllerName:
        //     The name of the controller.
        //
        // Returns:
        //     An anchor element (a element).
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        public static MvcHtmlString LocalizedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            return LinkExtensions.ActionLink(htmlHelper, Localization.GetResourceString(linkText), actionName, controllerName);
        }
        //
        // Summary:
        //     Returns an anchor element (a element) that contains the virtual path of the
        //     specified action.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. The object
        //     is typically created by using object initializer syntax.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes for the element. The attributes
        //     are retrieved through reflection by examining the properties of the object.
        //     The object is typically created by using object initializer syntax.
        //
        // Returns:
        //     An anchor element (a element).
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        public static MvcHtmlString LocalizedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, object htmlAttributes)
        {
            return LinkExtensions.ActionLink(htmlHelper, Localization.GetResourceString(linkText), actionName, routeValues, htmlAttributes);
        }
        //
        // Summary:
        //     Returns an anchor element (a element) that contains the virtual path of the
        //     specified action.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An anchor element (a element).
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        public static MvcHtmlString LocalizedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return LinkExtensions.ActionLink(htmlHelper, Localization.GetResourceString(linkText), actionName, routeValues, htmlAttributes);
        }
        //
        // Summary:
        //     Returns an anchor element (a element) that contains the virtual path of the
        //     specified action.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. The object
        //     is typically created by using object initializer syntax.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An anchor element (a element).
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        public static MvcHtmlString LocalizedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            return LinkExtensions.ActionLink(htmlHelper, Localization.GetResourceString(linkText), actionName, controllerName, routeValues, htmlAttributes);
        }
        //
        // Summary:
        //     Returns an anchor element (a element) that contains the virtual path of the
        //     specified action.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   routeValues:
        //     An object that contains the parameters for a route.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An anchor element (a element).
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.
        public static MvcHtmlString LocalizedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return LinkExtensions.ActionLink(htmlHelper, Localization.GetResourceString(linkText), actionName, controllerName, routeValues, htmlAttributes);
        }
        //
        // Summary:
        //     Returns an anchor element (a element) that contains the virtual path of the
        //     specified action.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action.
        //
        //   controllerName:
        //     The name of the controller.
        //
        //   protocol:
        //     The protocol for the URL, such as "http" or "https".
        //
        //   hostName:
        //     The host name for the URL.
        //
        //   fragment:
        //     The URL fragment name (the anchor name).
        //
        //   routeValues:
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. The object
        //     is typically created by using object initializer syntax.
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        // Returns:
        //     An anchor element (a element).
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The linkText parameter is null or empty.


        public static string ResourceString(this HtmlHelper helper, string key)
        {
            return Localization.GetResourceString(key);
        }
    }
}