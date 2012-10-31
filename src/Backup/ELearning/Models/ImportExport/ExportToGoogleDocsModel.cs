using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ELearning.Models.ImportExport
{
    public class ExportToGoogleDocsModel
    {
        public int FormID { get; set; }

        public string Name { get; set; }
        [Required]
        [DisplayLocalized("DocumentName")]
        public string DocumentName { get; set; }

        [Required]
        [DisplayLocalized("GoogleAccountEmail")]
        [RegularExpression(@".*@.*\..*")] // TODO Add better e-mail checking regex
        public string GEmail { get; set; }
        [Required]
        [DisplayLocalized("GoogleAccountPassword")]
        public string GPassword { get; set; }


        /// <summary>
        /// Initializes a new instance of the ExportToGoogleDocsModel class.
        /// </summary>
        public ExportToGoogleDocsModel()
        {
        }
        public ExportToGoogleDocsModel(int formID)
        {
            FormID = formID;
        }

    }
}