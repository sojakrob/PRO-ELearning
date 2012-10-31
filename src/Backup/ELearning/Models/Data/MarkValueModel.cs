using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class MarkValueModel : DataModelBase<MarkValue>
    {
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                IsNull = value < 0;
            }
        }
        private int _id;

        public string Name { get; set; }

        public bool IsNull { get; set; }


        public MarkValueModel()
        {
            ID = -1;
            Name = string.Empty;
        }
        public MarkValueModel(MarkValue data)
            : base(data)
        {
            ID = data.ID;
            Name = data.Name;
        }


        public override MarkValue ToData()
        {
            return MarkValue.CreateMarkValue(
                ID,
                Name
                );
        }
    }
}