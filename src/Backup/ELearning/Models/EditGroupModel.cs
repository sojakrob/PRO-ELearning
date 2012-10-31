using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using System.ComponentModel.DataAnnotations;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class EditGroupModel : GroupModel
    {
        public IEnumerable<UserModel> PossibleMembers { get; set; }


        public EditGroupModel()
        {

        }
        public EditGroupModel(IEnumerable<UserModel> possibleMembers)
        {
            PossibleMembers = possibleMembers;
        }
        public EditGroupModel(Group data, IEnumerable<UserModel> possibleMembers)
            : base(data)
        {
            PossibleMembers = possibleMembers;
        }
    }
}
