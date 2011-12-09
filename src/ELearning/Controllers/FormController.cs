using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Data;
using ELearning.Models;
using ELearning.Business.Managers;
using ELearning.Business.Storages;
using ELearning.Models.Data;
using System.Web.Security;

namespace ELearning.Controllers
{
    [Authorize]
    public class FormController : BaseController
    {
        FormManager _formManager;
        QuestionManager _questionManager;


        /// <summary>
        /// Initializes a new instance of the FormController class.
        /// </summary>
        /// <param name="formManager"></param>
        public FormController(FormManager formManager, QuestionManager questionManager)
        {
            _formManager = formManager;
            _questionManager = questionManager;
        }


        public ViewResult Index()
        {
            FillViewBag_Index();

            return View(ModelsFromArray<Form, FormModel>(_formManager.GetAll()));
        }

        public ViewResult Details(int id)
        {
            Form form = _formManager.GetForm(AuthenticationContext.LoggedUserSession.Email, id);

            return View(new FormModel(form));
        }

        public ActionResult Create()
        {
            FillViewBag_Create();

            return View();
        }

        [HttpPost]
        public ActionResult Create(FormModel form)
        {
            if (ModelState.IsValid)
            {
                int formID = _formManager.AddForm(CurrentLoggedUserModel.Email, form.ToData());
                if (formID != -1)
                    return RedirectToCreateEditQuestions(formID);
            }

            FillViewBag_Create();

            return View(form);
        }

        public ActionResult CreateEditQuestions(int id)
        {
            FormModel form = new FormModel(_formManager.GetForm(CurrentLoggedUserModel.Email, id));

            FillViewBag_CreateQuestionGroups(form);

            return View(form);
        }

        [HttpPost]
        public ActionResult CreateNewQuestion(QuestionGroupModel questionGroup)
        {
            if (ModelState.IsValid)
            {
                _questionManager.AddQuestionGroupWithQuestion(CurrentLoggedUserModel.Email, questionGroup.FormTemplateID, questionGroup.ToData());
            }

            return RedirectToCreateEditQuestions(questionGroup.FormTemplateID);
        }

        public ActionResult Edit(int id)
        {
            FillViewBag_Create();

            Form form = _formManager.GetForm(AuthenticationContext.LoggedUserSession.Email, id);

            return View(new FormModel(form));
        }

        [HttpPost]
        public ActionResult Edit(FormModel form)
        {
            if (ModelState.IsValid)
            {
                _formManager.EditForm(AuthenticationContext.LoggedUserSession.Email, form.ToData());
                return RedirectToAction("Index");
            }

            FillViewBag_Create();

            return View(form);
        }

        [HttpPost]
        public ActionResult EditQuestion_InlineText(int formID, int questionGroupID, int questionID, QuestionModel question)
        {
            Question q = question.ToData();
            q.ID = questionID;

            _questionManager.EditQuestion(CurrentLoggedUserModel.Email, q);

            return RedirectToCreateEditQuestions(formID);
        }
        [HttpPost]
        public ActionResult EditQuestion_MultilineText(int formID, int questionGroupID, int questionID, QuestionModel question)
        {
            // TODO Rid out of redundancy in EditQuestion_{0}
            Question q = question.ToData();
            q.ID = questionID;

            _questionManager.EditQuestion(CurrentLoggedUserModel.Email, q);

            return RedirectToCreateEditQuestions(formID);
        }
        [HttpPost]
        public ActionResult EditQuestion_Choice(int formID, int questionGroupID, int questionID, ChoiceQuestionModel question, int? correctChoice)
        {
            if (correctChoice.HasValue)
                question.ChoiceItems[correctChoice.Value].IsCorrect = true;

            ChoiceQuestion q = question.ToData() as ChoiceQuestion;
            q.ID = questionID;

            _questionManager.EditChoiceQuestion(CurrentLoggedUserModel.Email, q);

            return RedirectToCreateEditQuestions(formID);
        }
        [HttpPost]
        public ActionResult EditQuestion_MultipleChoice(int formID, int questionGroupID, int questionID, ChoiceQuestionModel question, int[] correctChoices)
        {
            if (correctChoices != null)
                for (int i = 0; i < correctChoices.Length; i++)
                    question.ChoiceItems[i].IsCorrect = true;

            ChoiceQuestion q = question.ToData() as ChoiceQuestion;
            q.ID = questionID;

            _questionManager.EditChoiceQuestion(CurrentLoggedUserModel.Email, q);

            return RedirectToCreateEditQuestions(formID);
        }

        public ActionResult AddAlternativeQuestion(int formTemplateID, int questionGroupID, int questionTypeID)
        {
            _questionManager.AddQuestion(CurrentLoggedUserModel.Email, questionGroupID, questionTypeID);

            return RedirectToCreateEditQuestions(formTemplateID);
        }

        public ActionResult AddChoiceItem(int formID, int questionInstanceID)
        {
            _questionManager.AddChoiceItem(CurrentLoggedUserModel.Email, questionInstanceID, string.Empty);

            return RedirectToCreateEditQuestions(formID);
        }


        private void FillViewBag_Index()
        {
            ViewBag.CurrentUserModel = CurrentLoggedUserModel;
        }
        private void FillViewBag_Create()
        {
            FillViewBag_Index();

            ViewBag.FormTypes = ModelsFromArray<FormType, FormTypeModel>(_formManager.GetFormTypes());
            ViewBag.DefaultFormType = _formManager.DefaultFormTypeID;
        }
        private void FillViewBag_CreateQuestionGroups(FormModel form)
        {
            FillViewBag_Index();

            ViewBag.Form = form;
            ViewBag.QuestionGroupTypes = ModelsFromArray<QuestionGroupType, QuestionGroupTypeModel>(_formManager.GetQuestionGroupTypes());
            ViewBag.DefaultQuestionGroupType = _formManager.DefaultQuestionGroupTypeID;
        }


        private ActionResult RedirectToCreateEditQuestions(int formID)
        {
            return RedirectToAction("CreateEditQuestions", new { id = formID });
        }        
    }
}