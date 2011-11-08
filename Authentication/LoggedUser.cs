using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;

namespace ELearning.Authentication
{
    public class LoggedUser
    {
        public User User
        {
            get { return _user; }
        }
        private User _user;


        public string Name
        {
            get { return _user.Name; }
        }

        public string Email
        {
            get { return _user.Email; }
        }
    }
}
