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
                new FormModel(_formManager.GetForm(id)),
                ModelsFromArray<FormInstance, FormInstanceModel>(_formManager.GetFormInstances(CurrentLoggedUserModel.Email, id))
                );

            return View(model);
        }

        public ActionResult StartForm(int id)
        {
            var fillingForm = _formManager.GetUserFillingFormInstanceWhileCheckingTime();
            if (fillingForm == null)
                _formManager.GenerateNewFormInstanceAndStartFilling(CurrentLoggedUserModel.Email, id);

            return RedirectToAction("FillingInProgress", new { openWindow = true });
        }

        public ActionResult FillingInProgress(bool? openWindow)
        {
            var fillingForm = _formManager.GetUserFillingFormInstanceWhileCheckingTime();
            if (fillingForm == null)
                return RedirectToHome();

            if(openWindow != null && openWindow.Value)
                ViewBag.OpenWindow = true;

            FormInstanceModel formModel = new FormInstanceModel(fillingForm);

            return View(formModel);
        }

        public ActionResult FillForm(int id)
        {
            var fillingForm = _formManager.GetUserFillingFormInstanceWhileCheckingTime();

            FormInstanceModel formModel = null;
            if (fillingForm != null)
                formModel = new FormInstanceModel(fillingForm);

            return View(formModel);
        }

        public ActionResult EndForm(int id)
        {
            bool success = SaveFilledAnswers(id);

            return View(success);
        }
        private bool SaveFilledAnswers(int formInstanceID)
        {
            bool result = true;

            var form = _formManager.GetFormInstance(formInstanceID);

            foreach (QuestionInstance question in form.Questions)
            {
                try
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

                            case QuestionGroupTypes.MultipleChoice:
                                answer = _formManager.CreateNewMultipleChoiceAnswer(GetMultipleChoiceQuestionAnswer(question));
                                break;

                            case QuestionGroupTypes.Scale:
                                answer = _formManager.CreateNewScaleAnswer(GetScaleQuestionAnswer(question));
                                break;

                            default:
                                throw new NotImplementedException();
                        }
                        _formManager.AddAnswer(CurrentLoggedUserModel.Email, formInstanceID, question.ID, answer);
                    }
                }
                catch (Exception ex)
                {
                    // TODO Log exception
                    result = false;
                }
            }
            _formManager.EndFormInstanceFilling(form.ID);

            return result;
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
        private int[] GetMultipleChoiceQuestionAnswer(QuestionInstance question)
        {
            string[] values = Request.Params.GetValues(string.Format("Q{0}", question.ID));
            int[] result = new int[values.Length];
            for (int i = 0; i < result.Length; i++)
            	result[i] = int.Parse(values[i]);

            return result;
        }
        private int GetScaleQuestionAnswer(QuestionInstance question)
        {
            return int.Parse(Request.Params[string.Format("Q{0}", question.ID)]);
        }

        public ActionResult ViewForm(int id)
        {
            FillViewBag_ViewForm();

            var form = _formManager.GetFormInstance(id);

            FormInstanceModel formModel = null;
            if (form != null)
                formModel = new FormInstanceModel(form);

            return View(formModel);
        }

        [HttpPost]
        public ActionResult Evaluate(int id, FormInstanceEvaluationModel evaluation)
        {
            if(ModelState.IsValid)
            {
                _formManager.EvaluateFormInstance(id, evaluation.ToData());
            }
            
            return RedirectToAction("ViewForm", new { id = id });
        }

        private void FillViewBag_ViewForm()
        {
            FillDefaultViewBag();

            if (CurrentLoggedUserModel.Type != UserTypes.Student)
            {
                var nullMark = new MarkValueModel().ToData();
                ViewBag.DefaultMark = nullMark.ID;
                var markValues = _formManager.GetMarkValues().ToList();
                markValues.Insert(0, nullMark);
                ViewBag.MarkValues = ModelsFromArray<MarkValue, MarkValueModel>(markValues);
            }
        }
    }
}
