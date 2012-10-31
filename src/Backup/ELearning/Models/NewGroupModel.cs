using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using System.ComponentModel.DataAnnotations;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class NewGroupModel
    {
        [Required]
        [DisplayLocalized("NameThing")]
        public string Name { get; set; }

        public IEnumerable<UserModel> PossibleSupervisors { get; set; }

        [Required]
        [DisplayLocalized("Supervisor")]
        public int SupervisorID { get; set; }


        public NewGroupModel()
        {
            PossibleSupervisors = new List<UserModel>();
        }
        public NewGroupModel(IEnumerable<User> possibleSupervisors)
        {
            PossibleSupervisors = UserModel.CreateFromArray<UserModel>(possibleSupervisors);
        }
        public NewGroupModel(Group data, IQueryable<User> possibleSupervisors)
        {
            Name = data.Name;
            PossibleSupervisors = UserModel.CreateFromArray<UserModel>(possibleSupervisors);
        }
    }
}
