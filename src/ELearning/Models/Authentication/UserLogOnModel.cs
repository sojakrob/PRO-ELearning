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
        [Display(Name="E-mail")]
        [RegularExpression(@".*@.*\..*")] // TODO Add better e-mail checking regex
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name="Keep me signed in")]
        public bool KeepSignedIn { get; set; }
    }
}