using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Storages;
using ELearning.Business.Exceptions;
using ELearning.Data.Enums;

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
                return AddQuestion(authorEmail, questionGroup.ID, questionGroup.Type.ID);

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

        public bool AddQuestion(string email, int questionGroupID, int questionTypeID)
        {
            // TODO Permissions
            Question question = CreateNewTypedQuestion(questionGroupID, questionTypeID);

            Context.Question.AddObject(question);
            Context.SaveChanges();

            if (IsChoiceQuestionType(question.QuestionGroup.TypeEnum))
            {
                AddChoiceItem(email, question.ID, string.Empty);
                AddChoiceItem(email, question.ID, string.Empty);
            }

            return true;
        }

        public bool AddChoiceItem(string email, int questionID, string text)
        {
            // TODO Permissions
            ChoiceItem item = CreateNewChoiceItem(questionID, text);
            item.Index = ((ChoiceQuestion)Context.Question.Single(q => q.ID == questionID)).ChoiceItems.Count;

            Context.ChoiceItem.AddObject(item);
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

        public static bool IsChoiceQuestionType(QuestionGroupTypes type)
        {
            return type == QuestionGroupTypes.Choice || type == QuestionGroupTypes.MultipleChoice;
        }

        private Question CreateNewTypedQuestion(int questionGroupID, int questionGroupTypeID)
        {
            string questionGroupName = Context.QuestionGroupType.Single(t => t.ID == questionGroupTypeID).Name;
            QuestionGroupTypes questionType = Shared.EnumUtility.EnumFromName<QuestionGroupTypes>(questionGroupName);
            switch (questionType)
            {
                case QuestionGroupTypes.InlineText:                    
                case QuestionGroupTypes.MultilineText:
                    return CreateNewQuestion(0, string.Empty, questionGroupID);

                case QuestionGroupTypes.Choice:
                    return CreateNewChoiceQuestion(0, string.Empty, string.Empty, string.Empty, questionGroupID, false);

                case QuestionGroupTypes.MultipleChoice:
                    return CreateNewMultipleChoiceQuestion(0, string.Empty, string.Empty, string.Empty, questionGroupID, false);

                case QuestionGroupTypes.Scale:
                    return CreateNewScaleQuestion(0, string.Empty, questionGroupID);                    

                default:
                    throw new NotImplementedException("QuestionGroupType not implemented");
            }
        }


        public static QuestionGroup CreateNewQuestionGroup(int id, int index, int questionGroupTypeID, int formTemplateID)
        {
            return QuestionGroup.CreateQuestionGroup(
                id,
                index,
                questionGroupTypeID,
                formTemplateID
                );
        }

        public static Question CreateNewQuestion(int id, string text, int questionGroupID)
        {
            return Question.CreateQuestion(
                id,
                text,
                questionGroupID
                );
        }
        public static Question CreateNewQuestion(int id, string text, string helpText, string explanation, int questionGroupID)
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

        public static ChoiceQuestion CreateNewChoiceQuestion(int id, string text, string helpText, string explanation, int questionGroupID, bool shuffle)
        {
            // HACK Show as Combo when Form type is Questionnaire
            return CreateNewChoiceQuestion(
                id,
                text,
                helpText,
                explanation,
                questionGroupID,
                shuffle,
                false
                );
        }
        private Question CreateNewMultipleChoiceQuestion(int id, string text, string helpText, string explanation, int questionGroupID, bool shuffle)
        {
            return CreateNewChoiceQuestion(
                id,
                text,
                helpText,
                explanation,
                questionGroupID,
                shuffle,
                true
                );
        }
        public static ChoiceQuestion CreateNewChoiceQuestion(int id, string text, string helpText, string explanation, int questionGroupID, bool shuffle, bool multiple)
        {
            // TODO Add IsMultiple flag into ChoiceQuestion entity
            ChoiceQuestion question = ChoiceQuestion.CreateChoiceQuestion(
                            id,
                            text,
                            questionGroupID,
                            shuffle
                            );

            return question;
        }
        private Question CreateNewScaleQuestion(int id, string text, int questionGroupID)
        {
            return ScaleQuestion.CreateScaleQuestion(
                id,
                string.Empty,
                questionGroupID,
                0,
                string.Empty,
                5,
                string.Empty,
                1
                );
        }
        public static ChoiceItem CreateNewChoiceItem(int questionID, string text)
        {
            return ChoiceItem.CreateChoiceItem(
                0,
                questionID,
                text,
                0,
                false,
                string.Empty
                );
        }
    }
}
