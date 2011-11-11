using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ELearning.Business.Exceptions
{
    public class PermissionException : ApplicationException
    {
        public string PermissionName
        {
            get { return _permissionName; }
            set { _permissionName = value; }
        }
        private string _permissionName;
        


        public PermissionException(string permissionName)
            : base()
        {
            _permissionName = permissionName;
        }
        public PermissionException(string permissionName, string message)
            : base(message)
        {
            _permissionName = permissionName;
        }
        public PermissionException(string permissionName, string message, Exception innerException)
            : base(message, innerException)
        {
            _permissionName = permissionName;
        }
        protected PermissionException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

    }
}
