using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Models.Data;

namespace ELearning.Models
{
    public class StudentModel : Data.DataModelBase<User>
    {
        // TODO Refactor with UserModel

        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }


        public StudentModel()
        {
            
        }
        public StudentModel(User data)
            : base(data)
        {
            ID = data.ID;
            Name = data.Name;
            Email = data.Email;
        }


        public override User ToData()
        {
            throw new NotImplementedException();
        }
    }
}