using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class FormModel : DataModelBase<Form>
    {
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }
        private int _id;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        private string _name;
        
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
            }
        }
        private string _text;


        /// <summary>
        /// Initializes a new instance of the FormModel class.
        /// </summary>
        /// <param name="form"></param>
        public FormModel()
        {
        }



        public static FormModel FromForm(Form form)
        {
            FormModel result = new FormModel()
            {
                ID = form.ID,
                Name = form.Name,
                Text = form.Text
            };

            return result;
        }
    }
}