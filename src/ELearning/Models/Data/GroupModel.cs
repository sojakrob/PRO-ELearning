using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using System.ComponentModel.DataAnnotations;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class GroupModel : DataModelBase<Group>
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        
        public UserModel Supervisor { get; set; }

        public IEnumerable<UserModel> Members 
        {
            get 
            {
                if(_members == null)
                    _members = DataModelBase<User>.CreateFromArray<UserModel>(_membersData);
                return _members; 
            }
            set { _members = value; }
        }
        private IEnumerable<UserModel> _members = null;
        private IEnumerable<User> _membersData;


        /// <summary>
        /// Initializes a new instance of the GroupModel class.
        /// </summary>
        public GroupModel()
        {
            Name = string.Empty;
            Supervisor = new UserModel();
        }
        public GroupModel(Group data)
        {
            ID = data.ID;
            Name = data.Name;
            Supervisor = new UserModel(data.Supervisor);
            _membersData = data.Members;
        }


        public override Group ToData()
        {
            return GroupManager.GetNewGroupInstance(
                ID,
                Name,
                Supervisor.ID
                );
        }
    }
}