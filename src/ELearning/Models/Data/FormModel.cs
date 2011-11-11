using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Data.Enums;

namespace ELearning.Models.Data
{
    public class FormModel : DataModelBase<Form>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public FormTypeModel Type { get; set; }
        public UserModel Author { get; set; }


        /// <summary>
        /// Initializes a new instance of the FormModel class.
        /// </summary>
        /// <param name="form"></param>
        public FormModel()
        {
        }
        public FormModel(Form data)
            : base(data)
        {
            ID = data.ID;
            Name = data.Name;
            Text = data.Text;
            Created = data.Created;

            if (data.Type == null)
                Type = new FormTypeModel();
            else
                Type = new FormTypeModel(data.Type);

            if (data.Author == null)
                Author = new UserModel();
            else
                Author = new UserModel(data.Author);
        }


        public override Form ToData()
        {
            return Form.CreateForm(
                ID,
                Name, 
                Text,
                Created, 
                Type == null ? 0 : Type.ID,
                Author == null ? 0 : Author.ID
                );
        }
    }
}