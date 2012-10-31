using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELearning.Models.GeneralView
{
    public class TopButtonModel
    {
        public string Text { get; set; }
        public string Action { get; set; }
        public string ControllerName { get; set; }
        public object RouteValues { get; set; }
        public string Target { get; set; }


        /// <summary>
        /// Initializes a new instance of the TopButtonModel class.
        /// </summary>
        public TopButtonModel(string text, string action, string controllerName)
        {
            Text = text;
            Action = action;
            ControllerName = controllerName;
            RouteValues = null;
            Target = null;
        }
        /// <summary>
        /// Initializes a new instance of the TopButtonModel class.
        /// </summary>
        public TopButtonModel(string text, string action, string controllerName, object routeValues, string target)
        {
            Text = text;
            Action = action;
            ControllerName = controllerName;
            RouteValues = routeValues;
            Target = target;
        }
    }
}