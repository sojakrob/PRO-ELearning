using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ELearning.Models.Data
{
    public class NewFormModel : FormModel
    {
        public IEnumerable<GroupModel> PossibleGroups { get; set; }

        /// <summary>
        /// Initializes a new instance of the NewFormModel class.
        /// </summary>
        /// <param name="form"></param>
        public NewFormModel()
            : base()
        {

        }
        public NewFormModel(Form data, IEnumerable<Group> possibleGroups)
            : base(data)
        {
            PossibleGroups = GroupModel.CreateFromArray<GroupModel>(possibleGroups);
        }
    }
}
