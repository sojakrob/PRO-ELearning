using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ELearning.Models.Authentication
{
    public class UserLogOnModel
    {
        [Required]
        [DisplayLocalized("Email")]
        [RegularExpression(@".*@.*\..*")] // TODO Add better e-mail checking regex
        public string Email { get; set; }
        [Required]
        [DisplayLocalized("Password")]
        public string Password { get; set; }
        [DisplayLocalized("KeepMeSignedIn")]
        public bool KeepSignedIn { get; set; }
    }
}