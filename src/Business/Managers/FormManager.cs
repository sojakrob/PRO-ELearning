﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Storages;
using ELearning.Business.Exceptions;
using ELearning.Business.Permissions;

namespace ELearning.Business.Managers
{
    public class FormManager : ManagerBase<Form>
    {
        private const int DEFAULT_ID = 0;


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
                    __groupManager = new GroupManager(_persistentStorage, _permissionsProvider);
                return __groupManager;
            }
        }
        private GroupManager __groupManager;



        /// <summary>
        /// Initializes a new instance of the FormManager class.
        /// </summary>
        /// <param name="persistentStorage"></param>
        public FormManager(IPersistentStorage persistentStorage, IPermissionsProvider permissionsProvider)
            : base(persistentStorage, permissionsProvider)
        {
            _permissionsProvider = permissionsProvider;

            _userManager = new UserManager(_persistentStorage, permissionsProvider);
            _questionManager = new QuestionManager(_persistentStorage, permissionsProvider);

            _random = new Random(Environment.TickCount);
        }


        public Form GetForm(int id)
        {
            // TODO Permissions
            return GetSingle(f => f.ID == id);
        }
        public Form GetForm(string userEmail, int id)
        {
            User user = _userManager.GetUser(userEmail);
            Form result = GetForm(id);
            if (result == null)
                throw new ArgumentException("Specified form not found");

            bool isOwner = (result.AuthorID == user.ID);
            if (!isOwner && !_userManager.GetUserPermissions(userEmail).Form_List)
                throw new PermissionException("Form_List");

            return result;
        }

        public FormInstance GetFormInstance(string userEmail, int id)
        {
            // TODO Permissions
            int userID = _userManager.GetUser(userEmail).ID;

            return Context.FormInstance.SingleOrDefault(f => f.ID == id);
        }
        public List<FormInstance> GetFormInstances(string userEmail, int id)
        {
            // TODO Permissions
            int userID = _userManager.GetUser(userEmail).ID;

            return Context.FormInstance.Where(i => i.FormTemplateID == id && i.SolverID == userID).ToList();
        }

        public List<FormInstance> GetFormInstances(string userEmail)
        {
            // TODO Permissions
            int userID = _userManager.GetUser(userEmail).ID;

            return Context.FormInstance.Where(i => i.SolverID == userID).ToList();
        }


        public int AddForm(string authorEmail, Form form)
        {
            if (!_userManager.GetUserPermissions(authorEmail).Form_CreateEdit)
                throw new PermissionException("Form_CreateEdit");

            User author = _userManager.GetUser(authorEmail);

            form.AuthorID = author.ID;
            form.Created = DateTime.Now;

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
            Form trueForm = GetForm(authorEmail, form.ID);
            
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

        public bool DeactivateForm(string authorEmail, int id)
        {
            throw new NotImplementedException();

            // TODO Implement Activate & Deactivate Form

            Form form = GetForm(authorEmail, id);
            User user = _userManager.GetUser(authorEmail);

            //if (form.AuthorID != user.ID && !_userManager.GetUserPermissions(authorEmail).Form_Deactivate)
            //    throw new PermissionException("Form_Deactivate");

            //form.IsActive = false;

            Context.SaveChanges();

            return true;
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

            var formInstance = GenerateNewFormInstance(user, formID);

            user.FillingForm = formInstance.ID;
            Context.SaveChanges();

            return formInstance;
        }

        public void EndFormInstanceFilling(string userEmail, int formID)
        {
            var user = _userManager.GetUser(userEmail);
            if (user.FillingForm == null || user.FillingForm.Value != formID)
                throw new ApplicationException("Cannot end filling of form which has not been filling");

            user.FillingForm = null;
            Context.SaveChanges();
        }

        public FormInstance GetUserFillingFormInstance(string userEmail)
        {
            var user = _userManager.GetUser(userEmail);
            if (user.FillingForm == null)
                return null;

            return GetFormInstance(userEmail, user.FillingForm.Value);
        }

        public FormInstance GenerateNewFormInstance(User user, int formID)
        {
            FormInstance formInstance = CreateNewFormInstance(user.ID, formID);

            Context.FormInstance.AddObject(formInstance);
            Context.SaveChanges();

            GenerateQuestionsForFormInstance(formInstance);

            return formInstance;
        }
        private bool GenerateQuestionsForFormInstance(FormInstance formInstance)
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

            var userFillingFormInstance = GetUserFillingFormInstance(userEmail);
            if (userFillingFormInstance == null || userFillingFormInstance.ID != formInstanceID)
                return false;

            // TODO If IsRequired check it is filled in

            var form = Context.FormInstance.SingleOrDefault(f => f.ID == formInstanceID);
            if (form == null)
                throw new ArgumentException("Specified form not exists");

            var question = Context.QuestionInstance.SingleOrDefault(q => q.ID == questionID);
            if (question == null)
                throw new ArgumentException("Specified question not exists");

            if (question.Answer != null)
                throw new ApplicationException("Question already has answer");

            // TODO Choice Question: Check if entered index exists in the questions etc.

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
        public Answer CreateNewScaleAnswer(int value)
        {
            return ScaleAnswer.CreateScaleAnswer(DEFAULT_ID, value);   
        }


        public IQueryable<FormType> GetFormTypes()
        {
            return Context.FormType;
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
    }
}
