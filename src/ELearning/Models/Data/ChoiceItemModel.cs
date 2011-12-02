using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class ChoiceItemModel : DataModelBase<ChoiceItem>
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }


        public ChoiceItemModel()
        {
            
        }
        public ChoiceItemModel(ChoiceItem data)
            : base(data)
        {
            ID = data.ID;
            Text = data.Text;
            IsCorrect = data.IsCorrect;
        }


        public override ChoiceItem ToData()
        {
            throw new NotImplementedException();
        }
    }
}
