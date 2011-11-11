using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Data.Enums;

namespace ELearning.Authentication
{
    public class UserSession
    {
        public string Email { get; set; }
        public UserTypes Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the UserSession class.
        /// </summary>
        public UserSession(string email, UserTypes type)
        {
            Email = email;
            Type = type;
        }

        
    }
}
