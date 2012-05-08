using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Data.Enums;

namespace ELearning.Models.Data
{
    public class UserTypeModel : DataModelBase<UserType>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; private set; }
        public UserTypes Enum { get; set; }


        /// <summary>
        /// Initializes a new instance of the UserTypeModel class.
        /// </summary>
        public UserTypeModel()
        {
        }
        /// <summary>
        /// Initializes a new instance of the UserTypeModel class.
        /// </summary>
        public UserTypeModel(UserType data)
            : base(data)
        {
            ID = data.ID;
            Name = data.Name;
            DisplayName = Localization.GetResourceString(Name);
            Enum = Shared.EnumUtility.EnumFromName<UserTypes>(Name);
        }


        public override UserType ToData()
        {
            return UserType.CreateUserType(
                ID,
                Name
                );
        }
    }
}