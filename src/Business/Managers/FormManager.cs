using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Storages;
using ELearning.Business.Exceptions;
using ELearning.Business.Permissions;
using ELearning.Data.Enums;

namespace ELearning.Business.Managers
{
    public class FormManager : ManagerBase<Form>
    {
        private const int DEFAULT_ID = 0;

        private const int TIMEDFORM_SAFE_SECONDS = 5;


        private Random _random;


        public int DefaultFormTypeID
        {
            get
            {
                return 2;
                // TODO Load from global settings
            }
        }
        public int DefaultQuestionGroupTypeID
        {
            get
            {
                return 1;
                // TODO Load from global settings
            }
        }

        private IPermissionsProvider _permissionsProvider;

        private UserManager _userManager;
        private QuestionManager _questionManager;

        private GroupManager _groupManager
        {
            get
            {
                if (__groupManager == null)
                    __groupManager = new GroupManager(_persistentStorage, _managers, _permissionsProvider);
                return __groupManager;
            }
        }
        private GroupManager __groupManager;



        public FormManager(IPersistentStorage persistentStorage, ManagersContainer container, IPermissionsProvider permissionsProvider)
            : base(persistentStorage, container,  permissionsProvider)
        {
            _permissionsProvider = permissionsProvider;

            _userManager = new UserManager(_persistentStorage, container, permissionsProvider);
            _questionManager = new QuestionManager(_persistentStorage, container,  permissionsProvider);

            _random = new Random(Environment.TickCount);
        }


        public override IQueryable<Form> GetAll()
        {
            if(Permissions.Form_List)
                return base.GetAll();

            var user = _userManager.GetUser(PermissionsProvider.UserID);
            var groups = _groupManager.GetUserGroups();

            var forms = from g in groups
                        from f in g.Forms
                        select f;

            if (Permissions.Form_CreateEdit)
            {
                forms = forms.Union(GetOwnedForms());
            }
            else
            {
                string activeState = FormStates.Active.ToString();
                forms = forms.Where(f => f.State.Name == activeState);
            }

            return forms;
        }
        public IQueryable<Form> GetNotArchivedForms()
        {
            string archivedState = FormStates.Archived.ToString();
            return GetAll().Where(f => f.State.Name != archivedState);
        }

        public Form GetForm(int id)
        {
            var result = GetSingle(f => f.ID == id);
            if (result == null && Context.Form.Count(f => f.ID == id) > 0)
                throw new PermissionException("Form_Get");

            return result;
        }

        public IQueryable<Form> GetOwnedForms()
        {
            return Context.Form.Where(f => f.AuthorID == PermissionsProvider.UserID);
        }

        public FormInstance GetFormInstance(int id)
        {
            var result = Context.FormInstance.Single(f => f.ID == id);
            if (result == null)
                throw new ArgumentException("FormInstance not found");

            if (result.IsPreview && result.SolverID != PermissionsProvider.UserID)
                throw new PermissionException("", "Form_AllPreviews");

            if (!Permissions.Form_List
                && result.SolverID != PermissionsProvider.UserID
                )
            {
                 var groups = _managers.Get<GroupManager>().GetAll().ToList();
                 if (PermissionsProvider.User.TypeEnum == UserTypes.Student || !result.FormTemplate.Groups.Any(g => groups.Contains(g)))
                    throw new PermissionException("Form_List");
            }

            return result;
        }
        public List<FormInstance> GetFormInstances(string userEmail, int formID)
        {
            // TODO Permissions
            int userID = _userManager.GetUser(userEmail).ID;

            return Context.FormInstance.Where(i => i.FormTemplateID == formID && i.SolverID == userID && !i.IsPreview).ToList();
        }

        public List<FormInstance> GetFormInstances(string userEmail)
        {
            // TODO Permissions
            int userID = _userManager.GetUser(userEmail).ID;

            return Context.FormInstance.Where(i => i.SolverID == userID && !i.IsPreview).ToList();
        }


        public int AddForm(string authorEmail, Form form)
        {
            if (!_userManager.GetUserPermissions(authorEmail).Form_CreateEdit)
                throw new PermissionException("Form_CreateEdit");

            User author = _userManager.GetUser(authorEmail);

            form.AuthorID = author.ID;
            form.Created = DateTime.Now;

            string stateString = FormStates.Inactive.ToString();
            form.State = GetFormStates().Where(s => s.Name == stateString).FirstOrDefault();

            try
            {
                Context.Form.AddObject(form);
                Context.SaveChanges();
            }
            catch (System.Data.OptimisticConcurrencyException ex)
            {
                // TODO Log exception
                return -1;
            }

            return form.ID;
        }

        public bool EditForm(string authorEmail, Form form)
        {
            Form trueForm = GetForm(form.ID);
            
            // TODO Check edit permissions

            trueForm.Name = form.Name;
            trueForm.Text = form.Text;
            trueForm.FormTypeID = form.FormTypeID;
            trueForm.Shuffle = form.Shuffle;
            trueForm.TimeToFill = form.TimeToFill;

            try
            {
                Context.SaveChanges();
            }
            catch (System.Data.OptimisticConcurrencyException ex)
            {
                // TODO Log exception
                return false;
            }

            return true;
        }

        public bool ChangeFormStateAndDeletePreviews(int id, FormStates state)
        {
            var form = GetForm(id);
            if (form == null)
                throw new ArgumentException("Form not found");

            if (form.AuthorID != PermissionsProvider.UserID && !Permissions.Form_CreateEdit_All)
                throw new PermissionException("Form_CreateEdit");

            string stateString = state.ToString();
            var stateObject = GetFormStates().Where(s => s.Name == stateString).FirstOrDefault();
            if (stateObject == null)
                throw new ApplicationException("FormState not found in DB");

            bool result = true;
            try
            {
                form.State = stateObject;

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO Log exception
                result = false;
            }

            try
            {
                IEnumerable<FormInstance> previews = GetFormPreviews(id).ToArray();
                foreach (var preview in previews)
                {
                    DeleteFormInstance(preview);
                }

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO Log exception
                result = false;
            }

            return result;
        }

        private IEnumerable<FormInstance> GetFormPreviews(int formID)
        {
            return GetForm(formID).FormInstances.Where(f => f.IsPreview);
        }

        public void SetFormAssignedGroups(int formID, int[] groupIDs)
        {
            var groupIDsToAdd = groupIDs.ToList();
            var form = GetForm(formID);
            foreach (var group in form.Groups)
            {
                if (groupIDsToAdd.Contains(group.ID))
                    groupIDsToAdd.Remove(group.ID);
                else
                    form.Groups.Remove(group);
            }
            foreach (var groupID in groupIDsToAdd)
                form.Groups.Add(_groupManager.GetGroup(groupID));

            Context.SaveChanges();
        }

        public FormInstance GenerateNewFormInstanceAndStartFilling(string userEmail, int formID)
        {
            User user = _userManager.GetUser(userEmail);

            var formInstance = GenerateAndSaveNewFormInstance(formID);

            user.FillingForm = formInstance.ID;
            Context.SaveChanges();

            return formInstance;
        }
        public FormInstance GetUserFillingFormInstanceWhileCheckingTime()
        {
            if (PermissionsProvider.User.FillingForm == null)
                return null;

            var formInstance = GetFormInstance(PermissionsProvider.User.FillingForm.Value);
            if (IsFormInstanceCurrentlyOvertime(formInstance))
            {
                EndFormInstanceFilling(PermissionsProvider.User.FillingForm.Value);
                return null;
            }

            return formInstance;
        }
        public void EndFormInstanceFilling(int formID)
        {
            var user = PermissionsProvider.User;
            if (user.FillingForm == null || user.FillingForm.Value != formID)
                throw new ApplicationException("Cannot end filling of form which has not been filling");

            user.FillingForm = null;
            Context.SaveChanges();
        }

        private bool IsFormInstanceCurrentlyOvertime(FormInstance formInstance)
        {
            if(formInstance == null)
                throw new ArgumentException("FormInstance is null");
            if(formInstance.FormTemplate.TimeToFill == null)
                return false;

            var lastEndTime = formInstance.Created.AddMinutes(formInstance.FormTemplate.TimeToFill.Value).AddSeconds(TIMEDFORM_SAFE_SECONDS);
            if (lastEndTime < DateTime.Now)
                return true;

            return false;
        }

        public bool EvaluateFormInstance(int formInstanceID, FormInstanceEvaluation newEvaluation)
        {
            if (newEvaluation == null)
                throw new ArgumentNullException("Evaluation");

            var form = GetFormInstance(formInstanceID);

            try
            {
                var evaluation = form.Evaluation;
                if (evaluation == null)
                {
                    evaluation = FormInstanceEvaluation.CreateFormInstanceEvaluation(DEFAULT_ID, newEvaluation.Note);

                    Context.FormInstanceEvaluation.AddObject(evaluation);
                }

                evaluation.Note = newEvaluation.Note;
                evaluation.MarkValueID = newEvaluation.MarkValueID;

                form.Evaluation = evaluation;

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log exception
                return false;
            }

            return true;
        }

        public FormInstance GenerateAndSaveNewFormInstance(int formID, bool isPreview = false)
        {
            var form = GetForm(formID);
            if (form == null)
                throw new ArgumentException("Form not found");

            FormInstance formInstance = CreateNewFormInstance(PermissionsProvider.UserID, formID);
            formInstance.IsPreview = isPreview;

            Context.FormInstance.AddObject(formInstance);
            Context.SaveChanges();

            GenerateAndSaveQuestionsForFormInstance(formInstance);

            return formInstance;
        }
        public FormInstance GenerateAndSaveNewFormInstancePreview(int formID)
        {
            return GenerateAndSaveNewFormInstance(formID, true);
        }

        private bool GenerateAndSaveQuestionsForFormInstance(FormInstance formInstance)
        {
            ICollection<QuestionGroup> questionGroups = formInstance.FormTemplate.QuestionGroups;

            if (formInstance.FormTemplate.Shuffle)
                questionGroups = Shared.CollectionUtility.Shuffle<QuestionGroup>(questionGroups);

            int index = DEFAULT_ID;
            foreach (QuestionGroup group in questionGroups)
            {
                var question = GenerateQuestionFromGroup(group, index, formInstance);

                Context.QuestionInstance.AddObject(question);
                formInstance.Questions.Add(question);

                index++;
            }

            Context.SaveChanges();

            return true;
        }
        private QuestionInstance GenerateQuestionFromGroup(QuestionGroup group, int index, FormInstance form)
        {
            if (group.Questions.Count == 0)
                throw new ApplicationException("QuestionGroup is empty");

            if (group.Questions.Count > 1)
                return GenerateQuestionFromTemplate(group.Questions.ElementAt(_random.Next(group.Questions.Count)), index, form);
            else
                return GenerateQuestionFromTemplate(group.Questions.First(), index, form);
        }
        private QuestionInstance GenerateQuestionFromTemplate(Question template, int index, FormInstance form)
        {
            return QuestionManager.CreateNewQuestionInstance(index, template.ID, form.ID);
                
        }

        public bool AddAnswer(string userEmail, int formInstanceID, int questionID, Answer answer)
        {
            // TODO Refactor to own class
            // TODO Permissions
            User user = _userManager.GetUser(userEmail);

            var userFillingFormInstance = GetUserFillingFormInstanceWhileCheckingTime();
            if (userFillingFormInstance == null || userFillingFormInstance.ID != formInstanceID)
                return false;

            // TODO If IsRequired check it is filled in

            var form = Context.FormInstance.SingleOrDefault(f => f.ID == formInstanceID && !f.IsPreview);
            if (form == null)
                throw new ArgumentException("Specified form not exists");

            var question = Context.QuestionInstance.SingleOrDefault(q => q.ID == questionID);
            if (question == null)
                throw new ArgumentException("Specified question not exists");

            if (question.Answer != null)
                throw new ApplicationException("Question already has answer");

            Context.Answer.AddObject(answer);
            question.Answer = answer;

            Context.SaveChanges();

            return true;
        }
        public Answer CreateNewAnswer()
        {
            // TODO Refactor to own class
            return Answer.CreateAnswer(DEFAULT_ID);
        }
        public TextAnswer CreateNewTextAnswer(string text)
        {
            return TextAnswer.CreateTextAnswer(DEFAULT_ID, text);
        }
        public ChoiceAnswer CreateNewChoiceAnswer(int index)
        {
            return ChoiceAnswer.CreateChoiceAnswer(DEFAULT_ID, index);
        }
        public MultipleChoiceAnswer CreateNewMultipleChoiceAnswer(int[] indices)
        {
            var result = MultipleChoiceAnswer.CreateMultipleChoiceAnswer(DEFAULT_ID);
            for (int i = 0; i < indices.Length; i++)
                result.Items.Add(CreateNewMultipleChoiceAnswerItem(indices[i], result.ID));	

            return result;
        }
        private MultipleChoiceAnswerItem CreateNewMultipleChoiceAnswerItem(int index, int parentID)
        {
            return MultipleChoiceAnswerItem.CreateMultipleChoiceAnswerItem(DEFAULT_ID, parentID, index);
        }
        public Answer CreateNewScaleAnswer(int value)
        {
            return ScaleAnswer.CreateScaleAnswer(DEFAULT_ID, value);   
        }


        public bool DeleteFormInstance(int id)
        {
            return DeleteFormInstance(Context.FormInstance.SingleOrDefault(f => f.ID == id));
        }
        private bool DeleteFormInstance(FormInstance form)
        {
            // TODO Permissions
            if (!form.IsPreview && !Permissions.Form_Delete)
                throw new PermissionException("Form_Delete");

            try
            {
                foreach (var question in form.Questions)
                {
                    Context.QuestionInstance.DeleteObject(question);
                }

                Context.FormInstance.DeleteObject(form);

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO Log exception
                return false;
            }

            return true;
        }

        public IQueryable<FormType> GetFormTypes()
        {
            return Context.FormType;
        }
        public IQueryable<FormState> GetFormStates()
        {
            return Context.FormState;
        }
        public IQueryable<MarkValue> GetMarkValues()
        {
            return Context.MarkValue;
        }
        public IQueryable<QuestionGroupType> GetQuestionGroupTypes()
        {
            return Context.QuestionGroupType;
        }


        public static FormInstance CreateNewFormInstance(int userID, int formID)
        {
            DateTime currentDateTime = DateTime.Now;
            return FormInstance.CreateFormInstance(
                DEFAULT_ID,
                currentDateTime,
                currentDateTime,
                userID,
                formID
                );
        }
        public static FormInstanceEvaluation CreateNewFormEvaluation()
        {
            return FormInstanceEvaluation.CreateFormInstanceEvaluation(
                DEFAULT_ID,
                string.Empty
                );
        }
    }
}
