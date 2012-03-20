using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Storages;
using ELearning.Business.Exceptions;
using ELearning.Data.Enums;
using ELearning.Business.Permissions;

namespace ELearning.Business.Managers
{
    public class QuestionManager : ManagerBase<Question>
    {
        private UserManager _userManager;

        private FormManager _formManager
        {
            get
            {
                if (__formManager == null)
                    __formManager = new FormManager(_persistentStorage, _managers, _permissionsProvider);
                return __formManager;
            }
        }
        private FormManager __formManager;

        private IPermissionsProvider _permissionsProvider;


        /// <summary>
        /// Initializes a new instance of the QuestionManager class.
        /// </summary>
        /// <param name="persistentStorage"></param>
        public QuestionManager(IPersistentStorage persistentStorage, ManagersContainer container, IPermissionsProvider permissionsProvider)
            : base(persistentStorage, container,  permissionsProvider)
        {
            _permissionsProvider = permissionsProvider;
            _userManager = new UserManager(_persistentStorage, container, permissionsProvider);
        }


        public Question GetQuestion(int id)
        {
            return GetSingle(q => q.ID == id);
        }

        public QuestionGroup GetQuestionGroup(int questionGroupID)
        {
            QuestionGroup group = Context.QuestionGroup.Single(q => q.ID == questionGroupID);
            if (group == null)
                throw new ArgumentException("Question Group not found");

            User user = PermissionsProvider.User;

            //if(group.ParentForm.AuthorID != user.ID && _userManager.GetUserPermissions(authorEmail).
            // TODO Permissions

            return group;
        }


        public bool AddQuestionGroupWithQuestion(string authorEmail, int formTemplateID, QuestionGroup questionGroup)
        {
            if (AddQuestionGroup(authorEmail, formTemplateID, questionGroup))
                return AddQuestion(authorEmail, questionGroup.ID, questionGroup.Type.ID);

            return false;
        }
        public bool AddQuestionGroup(string authorEmail, int formTemplateID, QuestionGroup questionGroup)
        {
            Form form = _formManager.GetForm( formTemplateID);
            User author = _userManager.GetUser(authorEmail);

            CheckQuestionCreateEditPermission(form, author);

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
            // TODO Refactor to Question

            Context.SaveChanges();

            return true;
        }
        public bool EditChoiceQuestion(string authorEmail, ChoiceQuestion question)
        {
            if (!EditQuestion(authorEmail, question))
                return false;

            ChoiceQuestion trueQuestion = Context.Question.Single(q => q.ID == question.ID) as ChoiceQuestion;
            trueQuestion.Shuffle = question.Shuffle;

            foreach (var choiceItem in question.ChoiceItems)
            {
                var trueChoiceItem = trueQuestion.ChoiceItems.SingleOrDefault(i => i.ID == choiceItem.ID);
                if (trueChoiceItem == null)
                {
                    trueQuestion.ChoiceItems.Add(choiceItem);
                }
                else
                {
                    trueChoiceItem.Text = choiceItem.Text;
                    trueChoiceItem.Index = choiceItem.Index;
                    trueChoiceItem.IsCorrect = choiceItem.IsCorrect;
                    trueChoiceItem.Explanation = choiceItem.Explanation;
                    trueChoiceItem.ImageUrl = choiceItem.ImageUrl;
                    // TODO Refactor to ChoiceItem
                }
            }

            // TODO Delete not present choice items

            Context.SaveChanges();

            return true;
        }

        public bool EditScaleQuestion(string authorEmail, ScaleQuestion question)
        {
            if (!EditQuestion(authorEmail, question))
                return false;

            var trueScaleQuestion = Context.Question.Single(q => q.ID == question.ID) as ScaleQuestion;
            trueScaleQuestion.MinValue = question.MinValue;
            trueScaleQuestion.MaxValue = question.MaxValue;
            trueScaleQuestion.Increment = question.Increment;

            Context.SaveChanges();
            return true;
        }
        private void CheckFormCreateEditPermission(Form form, User author)
        {
            bool isOwner = (form.AuthorID == author.ID);
            if (!isOwner && !_userManager.GetUserPermissions(author.Email).Form_CreateEdit_All)
                throw new PermissionException("Form_CreateEdit_All");
        }
        private void CheckQuestionCreateEditPermission(Form form, User author)
        {
            bool isOwner = (form.AuthorID == author.ID);
            if (!isOwner && !_userManager.GetUserPermissions(author.Email).Question_CreateEdit_All)
                throw new PermissionException("Question_CreateEdit_All");
        }

        public bool DeleteQuestionGroup(int formID, int questionGroupID)
        {
            var form = _formManager.GetForm(formID);
            CheckQuestionCreateEditPermission(form, PermissionsProvider.User);

            var questionGroup = GetQuestionGroup(questionGroupID);
            if (!form.QuestionGroups.Contains(questionGroup))
                throw new ApplicationException("QuestionGroup do not belongs to specified Form");

            var questions = questionGroup.Questions.ToArray();
            try
            {
                foreach (var question in questions)
                    DeleteQuestion(question);

                Context.QuestionGroup.DeleteObject(questionGroup);

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO Log exception
                return false;
            }
            return true;
        }
        public bool DeleteQuestion(int formID, int questionGroupID, int questionID)
        {
            var form = _formManager.GetForm(formID);
            CheckQuestionCreateEditPermission(form, PermissionsProvider.User);

            var questionGroup = GetQuestionGroup(questionGroupID);
            if (!form.QuestionGroups.Contains(questionGroup))
                throw new ApplicationException("QuestionGroup do not belongs to specified Form");

            var question = GetQuestion(questionID);
            if(!questionGroup.Questions.Contains(question))
                throw new ApplicationException("Question do not belongs to specified QuestionGroup");

            return DeleteQuestion(question);
        }
        private bool DeleteQuestion(Question question)
        {
            try
            {
                switch (question.QuestionGroup.TypeEnum)
                {
                    case QuestionGroupTypes.Choice:
                    case QuestionGroupTypes.MultipleChoice:
                        var choiceItems = ((ChoiceQuestion)question).ChoiceItems.ToArray();
                        foreach (var item in choiceItems)
                            Context.ChoiceItem.DeleteObject(item);
                        break;
                }

                Context.Question.DeleteObject(question);

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO Log exception
                return false;
            }
            return true;
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
            question.HelpText = helpText;
            question.Explanation = explanation;

            return question;
        }
        public static Question CreateNewScaleQuestion(int id, string text, int questionGroupID)
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
        public static ScaleQuestion CreateNewScaleQuestion(int id, string text, string helpText, string explanation, int questionGroupID, int minValue, int maxValue, int increment)
        {
            return ScaleQuestion.CreateScaleQuestion(
                id,
                text,
                questionGroupID,
                minValue,
                string.Empty,
                maxValue,
                string.Empty,
                increment
               );
        }
        public static ChoiceItem CreateNewChoiceItem(int questionID, string text)
        {
            return ChoiceItem.CreateChoiceItem(
                0,
                questionID,
                text,
                0,
                false
                );
        }
        public static ChoiceItem CreateNewChoiceItem(int ID, int questionID, string text, int index, bool isCorrect)
        {
            return ChoiceItem.CreateChoiceItem(
                ID,
                questionID,
                text,
                index,
                isCorrect
                );
        }

        public static QuestionInstance CreateNewQuestionInstance(int index, int questionID, int formInstanceID)
        {
            return QuestionInstance.CreateQuestionInstance(
                0,
                index,
                questionID,
                formInstanceID
                );
        }
    }
}
