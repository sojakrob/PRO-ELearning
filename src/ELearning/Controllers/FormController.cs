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
using ELearning.Data.Enums;
using ELearning.Authentication;
using ELearning.Business.ImportExport;
using ELearning.Business.ImportExport.Google;
using ELearning.Models.ImportExport;
using ELearning.Business.Reporting;
using System.Security.Authentication;

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


        [AuthorizeUserType(UserType = UserTypes.Student)]
        public ViewResult Index()
        {
            FillDefaultViewBag();

            return View(ModelsFromArray<Form, FormFillsModel>(_formManager.GetNotArchivedForms(), _formManager));
        }

        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult Create()
        {
            FillViewBag_Create();

            var form = new NewFormModel();
            form.PossibleGroups = GroupModel.CreateFromArray<GroupModel>(_groupManager.GetAll());

            return View(form);
        }

        [HttpPost]
        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult Create(NewFormModel form, int[] assignedGroupIDs)
        {
            if (ModelState.IsValid)
            {
                int formID = _formManager.AddForm(form.ToData());
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

        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult CreateEditQuestions(int id, int? addedQuestionID)
        {
            FormModel form = new FormModel(_formManager.GetForm(id));

            FillViewBag_CreateQuestionGroups(form);
            ViewBag.AddedQuestionID = addedQuestionID;

            return View(form);
        }

        [HttpPost]
        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult CreateNewQuestion(QuestionGroupModel questionGroup)
        {
            if (ModelState.IsValid)
            {
                bool added = _questionManager.AddQuestionGroupWithQuestion(questionGroup.FormTemplateID, questionGroup.ToData());
                if (added)
                    ViewBag.AddedQuestionID = _questionManager.GetLastAddedQuestionGroupOf(questionGroup.FormTemplateID).ID;
            }

            return RedirectToCreateEditQuestions(questionGroup.FormTemplateID, ViewBag.AddedQuestionID);
        }

        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult Edit(int id)
        {
            FillViewBag_Create();

            Form form = _formManager.GetForm(id);

            return View(new NewFormModel(form, _groupManager.GetPossibleGroupsForForm(id)));
        }

        [HttpPost]
        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult Edit(NewFormModel form, int[] assignedGroupIDs)
        {
            if (ModelState.IsValid)
            {
                _formManager.EditForm(form.ToData());

                if (assignedGroupIDs == null)
                    assignedGroupIDs = new int[] { };
                _formManager.SetFormAssignedGroups(form.ID, assignedGroupIDs);

                return RedirectToAction("Index");
            }

            FillViewBag_Create();
            form.PossibleGroups = GroupModel.CreateFromArray<GroupModel>(_groupManager.GetAll());

            return View(form);
        }

        [HttpPost]
        [AuthorizeUserType(UserType = UserTypes.Lector)]
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
        [AuthorizeUserType(UserType = UserTypes.Lector)]
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
        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult EditQuestion_Choice(int formID, int questionGroupID, int questionID, ChoiceQuestionModel question, int? correctChoice)
        {
            if (!ModelState.IsValid)
                return RedirectToCreateEditQuestions(formID);

            if (correctChoice.HasValue)
                question.ChoiceItems[correctChoice.Value].IsCorrect = true;

            ChoiceQuestion q = question.ToData() as ChoiceQuestion;
            q.ID = questionID;

            if (Request.Params["Shuffle"] == null)
                q.Shuffle = false;
            else
                q.Shuffle = true;

            _questionManager.EditChoiceQuestion(CurrentLoggedUserModel.Email, q);

            return RedirectToCreateEditQuestions(formID);
        }
        [HttpPost]
        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult EditQuestion_MultipleChoice(int formID, int questionGroupID, int questionID, ChoiceQuestionModel question, int[] correctChoices)
        {
            if (!ModelState.IsValid)
                return RedirectToCreateEditQuestions(formID);

            if (correctChoices != null)
                for (int i = 0; i < correctChoices.Length; i++)
                    question.ChoiceItems[correctChoices[i]].IsCorrect = true;

            ChoiceQuestion q = question.ToData() as ChoiceQuestion;
            q.ID = questionID;

            _questionManager.EditChoiceQuestion(CurrentLoggedUserModel.Email, q);

            return RedirectToCreateEditQuestions(formID);
        }
        [HttpPost]
        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult EditQuestion_Scale(int formID, int questionGroupID, int questionID, ScaleQuestionModel question)
        {
            if (!ModelState.IsValid)
                return RedirectToCreateEditQuestions(formID);

            ScaleQuestion q = question.ToData() as ScaleQuestion;
            q.ID = questionID;

            _questionManager.EditScaleQuestion(CurrentLoggedUserModel.Email, q);

            return RedirectToCreateEditQuestions(formID);
        }

        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult AddAlternativeQuestion(int formTemplateID, int questionGroupID, int questionTypeID)
        {
            _questionManager.AddQuestion(questionGroupID, questionTypeID);

            return RedirectToCreateEditQuestions(formTemplateID);
        }

        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult DuplicateQuestionGroup(int formTemplateID, int questionGroupID)
        {
            bool added = _questionManager.DuplicateQuestionGroup(formTemplateID, questionGroupID);
            if (added)
                ViewBag.AddedQuestionID = _questionManager.GetLastAddedQuestionGroupOf(formTemplateID).ID;

            return RedirectToCreateEditQuestions(formTemplateID);
        }

        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult AddChoiceItem(int formID, int questionInstanceID)
        {
            _questionManager.AddChoiceItem(questionInstanceID, string.Empty);

            return RedirectToCreateEditQuestions(formID);
        }

        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult DeleteQuestion(int formID, int questionID)
        {
            _questionManager.DeleteQuestionGroup(formID, questionID);

            return RedirectToCreateEditQuestions(formID);
        }
        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult DeleteAlternativeQuestion(int formID, int questionID, int alternativeQuestionID)
        {
            _questionManager.DeleteQuestion(formID, questionID, alternativeQuestionID);

            return RedirectToCreateEditQuestions(formID);
        }

        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult FormFills(int id)
        {
            var form = _formManager.GetForm(id);

            return View(new FormFillsModel(form, _formManager));
        }

        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult ChangeState(int id, FormStates state)
        {
            _formManager.ChangeFormStateAndDeletePreviews(id, state);

            return RedirectToAction("Index");
        }

        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult ShowPreview(int? id, bool? print)
        {
            if (id == null)
                return RedirectToHome();

            var previewInstance = _formManager.GenerateAndSaveNewFormInstancePreview(id.Value);

            return RedirectToAction("ViewForm", "FormInstance", new { id = previewInstance.ID, print = print });
        }

        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult ExportToGoogleDocs(int id)
        {
            var model = new ExportToGoogleDocsModel(id);
            model.Name = _formManager.GetForm(id).Name;
            model.DocumentName = string.Format("{0} {1}", model.Name, DateTime.Now.ToShortDateString());

            return View(model);
        }
        [HttpPost]
        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult ExportToGoogleDocs(ExportToGoogleDocsModel model)
        {
            var report = FormFillsDataReportCreator.CreateReport(model.FormID, _formManager);

            bool exported = GoogleDocsExporter.UploadReport(report, model.DocumentName, model.GEmail, model.GPassword, Server, new Localization());
            if (!exported)
                return RedirectToAction("ExportToGoogleDocs", model);

            return RedirectToAction("FormFills", new { id = model.FormID });
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


        private ActionResult RedirectToCreateEditQuestions(int formID, int? addedQuestionID = null)
        {
            return RedirectToAction("CreateEditQuestions", new { id = formID, addedQuestionID = addedQuestionID });
        }
    }
}