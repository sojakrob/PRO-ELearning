using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Models.Data;

namespace ELearning.Models
{
    public class HomePageModel
    {
        public IEnumerable<FormFillsModel> FormFills { get; set; }
        public IEnumerable<TextBookModel> TextBooks { get; set; }


        /// <summary>
        /// Initializes a new instance of the HomePageModel class.
        /// </summary>
        public HomePageModel(IEnumerable<FormFillsModel> formFills, IEnumerable<TextBookModel> textBooks)
        {
            FormFills = formFills;
            TextBooks = textBooks;
        }
    }
}