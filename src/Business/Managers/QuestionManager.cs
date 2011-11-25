using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Storages;
using ELearning.Business.Exceptions;

namespace ELearning.Business.Managers
{
    public class QuestionManager : ManagerBase<Question>
    {
        private UserManager _userManager;
        private FormManager _formManager;


        /// <summary>
        /// Initializes a new instance of the QuestionManager class.
        /// </summary>
        /// <param name="persistentStorage"></param>
        public QuestionManager(IPersistentStorage persistentStorage)
            : base(persistentStorage)
        {
            _userManager = new UserManager(_persistentStorage);
            _formManager = new FormManager(_persistentStorage);
        }


        public Question GetQuestion(int id)
        {
            return GetSingle(q => q.ID == id);
        }

        public QuestionGroup GetQuestionGroup(string authorEmail, int questionGroupID)
        {
            QuestionGroup group = Context.QuestionGroup.Single(q => q.ID == questionGroupID);
            if(group == null)
                throw new ArgumentException("Question Group not found");

            User user = _userManager.GetUser(authorEmail);

            //if(group.ParentForm.AuthorID != user.ID && _userManager.GetUserPermissions(authorEmail).
            // TODO Permissions

            return group;
        }


        public bool AddQuestionGroupWithQuestion(string authorEmail, int formTemplateID, QuestionGroup questionGroup)
        {
            if(AddQuestionGroup(authorEmail, formTemplateID, questionGroup))
                return AddQuestion(authorEmail, questionGroup.ID);

            return false;
        }
        public bool AddQuestionGroup(string authorEmail, int formTemplateID, QuestionGroup questionGroup)
        {
            Form form = _formManager.GetForm(authorEmail, formTemplateID);
            User author = _userManager.GetUser(authorEmail);

            CheckCreateEditPermission(form, author);

            questionGroup.FormTemplateID = form.ID;
            questionGroup.Index = form.QuestionGroups == null ? 1 : form.QuestionGroups.Count + 1;

            Context.QuestionGroup.AddObject(questionGroup);
            Context.SaveChanges();

            return true;
        }

        public bool AddQuestion(string authorEmail, int questionGroupID)
        {
            // TODO Permissions
            Question question = CreateNewQuestionInstance(0, string.Empty, questionGroupID);

            Context.Question.AddObject(question);
            Context.SaveChanges();

            return true;
        }


        public bool EditQuestion(string authorEmail, Question question)
        {
            // TODO Permissions
            Question trueQuestion = Context.Question.Single(q => q.ID == question.ID);

            trueQuestion.Text = question.Text;
            trueQuestion.HelpText = question.HelpText;
            trueQuestion.Explanation = question.Explanation;

            Context.SaveChanges();

            return true;
        }
        private void CheckCreateEditPermission(Form form, User author)
        {
            bool isOwner = (form.AuthorID == author.ID);
            if (!isOwner && !_userManager.GetUserPermissions(author.Email).Form_CreateEdit_All)
                throw new PermissionException("Form_CreateEdit_All");
        }


        public static QuestionGroup CreateNewQuestionGroupInstance(int id, int index, int questionGroupTypeID, int formTemplateID)
        {
            return QuestionGroup.CreateQuestionGroup(
                id,
                index,
                questionGroupTypeID,
                formTemplateID
                );
        }
        public static Question CreateNewQuestionInstance(int id, string text, int questionGroupID)
        {
            return Question.CreateQuestion(
                id,
                text,
                questionGroupID
                );
        }
        public static Question CreateNewQuestionInstance(int id, string text, string helpText, string explanation, int questionGroupID)
        {
            Question result = Question.CreateQuestion(
                id,
                text,
                questionGroupID
                );
            result.HelpText = helpText;
            result.Explanation = explanation;

            return result;
        }
    }
}
