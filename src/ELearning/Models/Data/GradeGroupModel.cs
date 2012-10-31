using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELearning.Models.Data
{
    public class GradeGroupModel
    {
        public int ID { get; set; }
        public int FormID { get; set; }
        public List<GradeModel> Grades { get; set; }

        //public Grade NewGrade { get; set; }


        public GradeGroupModel()
        {
            
        }
       ///// public GradeGroupModel(GradeGroup data)
       /////     : base(data)
       //// {
       //     ID = data.ID;
       //     FormTemplateID = data.FormTemplateID;
       //     Index = data.Index;
       //     Type = new QuestionGroupTypeModel(data.Type);
       //     Questions = QuestionModelsConvertor.CreateFromArray(data.Questions);
       // }


        //public override GradeGroup ToData()
        //{
        //    from EDMX designer
        //}
    }
    }
