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
        private FormManager _formManager;
        private QuestionManager _questionManager;
        private GroupManager _groupManager;


        public FormController(FormManager formManager, QuestionManager questionManager, GroupManager groupManager)
        {
            _formManager = formManager;
            _questionManager = questionManager;
            _groupManager = groupManager;
        }


        public ViewResult Index()
        {
            FillDefaultViewBag();

            return View(ModelsFromArray<Form, FormModel>(_formManager.GetAll()));
        }

        public ViewResult Details(int id)
        {
            Form form = _formManager.GetForm(id);

            return View(new FormModel(form));
        }

        public ActionResult Create()
        {
            FillViewBag_Create();

            var form = new NewFormModel();
            form.PossibleGroups = GroupModel.CreateFromArray<GroupModel>(_groupManager.GetAll());

            return View(form);
        }

        [HttpPost]
        public ActionResult Create(NewFormModel form, int[] assignedGroupIDs)
        {
            if (ModelState.IsValid)
            {
                int formID = _formManager.AddForm(CurrentLoggedUserModel.Email, form.ToData());
                if (formID != -1)
                {
                    if (assignedGroupIDs == null)
                        assignedGroupIDs = new int[] { };
                    _formManager.SetFormAssignedGroups(formID, assignedGroupIDs);
                    return RedirectToCreateEditQuestions(formID);
                }
            }

            FillViewBag_Create();
            form.PossibleGroups = GroupModel.CreateFromArray<GroupModel>(_groupManager.GetAll());

            
            return View(form);
        }

        public ActionResult CreateEditQuestions(int id)
        {
            FormModel form = new FormModel(_formManager.GetForm(id));

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

            Form form = _formManager.GetForm(id);

            return View(new NewFormModel(form, _groupManager.GetPossibleGroupsFor(id)));
        }

        [HttpPost]
        public ActionResult Edit(NewFormModel form, int[] assignedGroupIDs)
        {
            if (ModelState.IsValid)
            {
                _formManager.EditForm(AuthenticationContext.LoggedUserSession.Email, form.ToData());
                _formManager.SetFormAssignedGroups(form.ID, assignedGroupIDs);
                return RedirectToAction("Index");
            }

            FillViewBag_Create();
            form.PossibleGroups = GroupModel.CreateFromArray<GroupModel>(_groupManager.GetAll());

            return View(form);
        }

        [HttpPost]
        public ActionResult EditQuestion_InlineText(int formID, int questionGroupID, int questionID, QuestionModel question)
        {
            if (!ModelState.IsValid)
                return RedirectToCreateEditQuestions(formID);

            Question q = question.ToData();
            q.ID = questionID;

            _questionManager.EditQuestion(CurrentLoggedUserModel.Email, q);

            return RedirectToCreateEditQuestions(formID);
        }
        [HttpPost]
        public ActionResult EditQuestion_MultilineText(int formID, int questionGroupID, int questionID, QuestionModel question)
        {
            if (!ModelState.IsValid)
                return RedirectToCreateEditQuestions(formID);

            // TODO Rid out of redundancy in EditQuestion_{0}
            Question q = question.ToData();
            q.ID = questionID;

            _questionManager.EditQuestion(CurrentLoggedUserModel.Email, q);

            return RedirectToCreateEditQuestions(formID);
        }
        [HttpPost]
        public ActionResult EditQuestion_Choice(int formID, int questionGroupID, int questionID, ChoiceQuestionModel question, int? correctChoice)
        {
            if (!ModelState.IsValid)
                return RedirectToCreateEditQuestions(formID);

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
            if (!ModelState.IsValid)
                return RedirectToCreateEditQuestions(formID);

            if (correctChoices != null)
                for (int i = 0; i < correctChoices.Length; i++)
                    question.ChoiceItems[i].IsCorrect = true;

            ChoiceQuestion q = question.ToData() as ChoiceQuestion;
            q.ID = questionID;

            _questionManager.EditChoiceQuestion(CurrentLoggedUserModel.Email, q);

            return RedirectToCreateEditQuestions(formID);
        }
        [HttpPost]
        public ActionResult EditQuestion_Scale(int formID, int questionGroupID, int questionID, ScaleQuestionModel question)
        {
            if (!ModelState.IsValid)
                return RedirectToCreateEditQuestions(formID);

            ScaleQuestion q = question.ToData() as ScaleQuestion;
            q.ID = questionID;

            _questionManager.EditScaleQuestion(CurrentLoggedUserModel.Email, q);

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

        public ActionResult FormFills(int id)
        {
            var form = _formManager.GetForm(id);

            return View(new FormFillsModel(form));
        }

        private void FillViewBag_Create()
        {
            FillDefaultViewBag();

            ViewBag.FormTypes = ModelsFromArray<FormType, FormTypeModel>(_formManager.GetFormTypes());
            ViewBag.DefaultFormType = _formManager.DefaultFormTypeID;
        }
        private void FillViewBag_CreateQuestionGroups(FormModel form)
        {
            FillDefaultViewBag();

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