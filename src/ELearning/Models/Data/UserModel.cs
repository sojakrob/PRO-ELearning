using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Data.Enums;
using System.ComponentModel.DataAnnotations;
using ELearning.Business.Managers;

namespace ELearning.Models.Data
{
    public class UserModel : DataModelBase<User>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required] // TODO Add Regex check etc.
        public string Email { get; set; }
        
        [Required]
        public UserTypeModel Type { get; set; }

        public IEnumerable<GroupModel> AssignedGroups 
        {
            get { }
            set { }
        }
        private IEnumerable<GroupModel> _assignedGroups = null;
        private IEnumerable<Group> _assignedGroupsData;


        /// <summary>
        /// Initializes a new instance of the UserModel class.
        /// </summary>
        public UserModel()
        {
            Name = string.Empty;
            AssignedGroups = new List<GroupModel>();
        }
        public UserModel(User data)
            : base(data)
        {
            ID = data.ID;
            Name = data.Name;
            Email = data.Email;

            if (data.Type == null)
                Type = new UserTypeModel();
            else
                Type = new UserTypeModel(data.Type);

            _assignedGroupsData = data.Groups;
        }


        public override User ToData()
        {
            return UserManager.GetNewUserInstance(
                ID,
                Email,
                Type.ID,
                string.Empty,
                true
                );
        }
    }
}
