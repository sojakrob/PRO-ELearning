using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public class GradeModel
    {
        private const int TEXT_MAX_LENGTH = 80;


        public int ID { get; set; }

        [Required]
        [DisplayLocalized("Grade")]
        public string GradeName { get; set; }
        

        [Required]
        [DisplayLocalized("Rate")]
        public string Rate { get; set; }

        

        public GradeGroup gradeGroup{ get; set; }


        public GradeModel()
        {

        }
        //public GradeModel(Grade data)
        //    : base(data)
        //{
        //    ID = data.ID;
        //    GradeName= data.Name;
        //    Rate = data.Value;
        //    gradeGroup = data.GradeGroup;

        //}


        //public override Grade ToData()
        //{
        //    return Grade.CreateGrade(ID, GradeName, Rate);
        //}
    }
}