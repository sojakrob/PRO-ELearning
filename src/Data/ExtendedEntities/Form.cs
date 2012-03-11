using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Shared;

namespace ELearning.Data
{
    public partial class Form
    {
        private const int DEFAULT_STATE_ID = 1;


        public Enums.FormTypes TypeEnum
        {
            get { return EnumUtility.EnumFromName<Enums.FormTypes>(Type.Name); }
        }
        public Enums.FormStates StateEnum
        {
            get { return EnumUtility.EnumFromName<Enums.FormStates>(State.Name); }
        }


        public static Form CreateForm(
            global::System.Int32 id,
            global::System.String name,
            global::System.DateTime created,
            global::System.Int32 formTypeID,
            global::System.Int32 authorID)
        {
            return CreateForm(id, name, created, formTypeID, authorID, DEFAULT_STATE_ID);
        }
    }
}
