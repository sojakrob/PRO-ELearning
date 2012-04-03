using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;
using System.ComponentModel.DataAnnotations;

namespace ELearning.Models.Data
{
    public class NewTextBookModel : TextBookModel
    {
        public IEnumerable<GroupModel> PossibleGroups { get; set; }


        public NewTextBookModel()
        {

        }
        public NewTextBookModel(TextBook data, IEnumerable<Group> possibleGroups)
            : base(data)
        {
            PossibleGroups = GroupModel.CreateFromArray<GroupModel>(possibleGroups);
        }
    }
}
