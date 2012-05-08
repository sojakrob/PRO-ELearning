using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ELearning.Models.Settings
{
    public class ChangePasswordModel
    {
        [Required]
        [DisplayLocalized("OldPassword")]
        public string OldPassword { get; set; }
        [Required]
        [DisplayLocalized("NewPassword")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayLocalized("NewPasswordAgain")]
        public string NewPasswordAgain { get; set; }


        public ChangePasswordModel()
        {
            
        }
    }
}