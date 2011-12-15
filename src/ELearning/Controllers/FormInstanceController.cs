using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Business.Managers;
using ELearning.Models.Data;
using ELearning.Data;
using ELearning.Data.Enums;

namespace ELearning.Controllers
{
    public class FormInstanceController : BaseController
    {
        FormManager _formManager;


        /// <summary>
        /// Initializes a new instance of the FormInstanceController class.
        /// </summary>
        /// <param name="formManager"></param>
        public FormInstanceController(FormManager formManager)
        {
            _formManager = formManager;
        }



        public ActionResult Index(int id)
        {
            ELearning.Models.FormInstancesModel model = new ELearning.Models.FormInstancesModel(
                new FormModel(_formManager.GetForm(CurrentLoggedUserModel.Email, id)), 
                ModelsFromArray<FormInstance, FormInstanceModel>(_formManager.GetFormInstances(CurrentLoggedUserModel.Email, id))
                );

            return View(model);
        }

        public ActionResult FillForm(int id)
        {
            FormInstanceModel formInstance = new FormInstanceModel(_formManager.GenerateNewFormInstance(CurrentLoggedUserModel.Email, id));
            return View(formInstance);
        }

        public ActionResult EndForm(int id)
        {
            SaveFilledAnswers(id);

            return View();
        }
        private void SaveFilledAnswers(int formInstanceID)
        {
            var form = _formManager.GetFormInstance(CurrentLoggedUserModel.Email, formInstanceID);
            foreach (QuestionInstance question in form.Questions)
            {
                if (IsQuestionAnswerInRequest(question))
                {
                    Answer answer = null;
                    switch (question.QuestionTemplate.QuestionGroup.TypeEnum)
                    {
                        case QuestionGroupTypes.InlineText:
                            answer = _formManager.CreateNewTextAnswer(GetTextQuestionAnswer(question));
                            break;

                        case QuestionGroupTypes.Choice:
                            answer = _formManager.CreateNewChoiceAnswer(GetChoiceQuestionAnswer(question));
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                    _formManager.AddAnswer(CurrentLoggedUserModel.Email, formInstanceID, question.ID, answer);
                }
            }
        }
        private bool IsQuestionAnswerInRequest(QuestionInstance question)
        {
            return Request.Params[string.Format("Q{0}", question.ID)] != null;
        }
        private string GetTextQuestionAnswer(QuestionInstance question)
        {
            return Request.Params[string.Format("Q{0}", question.ID)] as string;
        }
        private int GetChoiceQuestionAnswer(QuestionInstance question)
        {
            return int.Parse(Request.Params[string.Format("Q{0}", question.ID)]);
        }
    }
}
