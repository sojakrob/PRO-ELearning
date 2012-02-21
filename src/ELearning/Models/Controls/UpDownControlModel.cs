using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELearning.Models.Controls
{
    public class UpDownControlModel
    {
        public string Guid { get; private set; }
        public string ParentPropertyName { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }


        /// <summary>
        /// Initializes a new instance of the UpDownControlModel class.
        /// </summary>
        public UpDownControlModel(string parentPropertyName, int value)
            :this(parentPropertyName, value, string.Empty)
        {
        }
        /// <summary>
        /// Initializes a new instance of the UpDownControlModel class.
        /// </summary>
        public UpDownControlModel(string parentPropertyName, int value, string text)
        {
            Guid = System.Guid.NewGuid().ToString();
            ParentPropertyName = parentPropertyName;
            Text = text;
            Value = value;
        }
    }
}