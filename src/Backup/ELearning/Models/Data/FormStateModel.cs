using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data.Enums;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class FormStateModel : DataModelBase<FormState>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public FormStates Enum { get; set; }


        public FormStateModel()
        {

        }
        public FormStateModel(FormState data)
            : base(data)
        {
            ID = data.ID;
            Name = data.Name;
            Enum = Shared.EnumUtility.EnumFromName<FormStates>(Name);
        }


        public override FormState ToData()
        {
            return FormState.CreateFormState(
                ID,
                Name
                );
        }
    }
}