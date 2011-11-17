using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Data.Enums;

namespace ELearning.Models.Data
{
    public class FormTypeModel : DataModelBase<FormType>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public FormTypes Enum { get; set; }


        public FormTypeModel()
        {

        }
        public FormTypeModel(FormType data)
            : base(data)
        {
            ID = data.ID;
            Name = data.Name;
            Enum = Shared.EnumUtility.EnumFromName<FormTypes>(Name);
        }


        public override FormType ToData()
        {
            return FormType.CreateFormType(
                ID,
                Name
                );
        }
    }
}
