using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Storages;
using ELearning.Business.Exceptions;

namespace ELearning.Business.Managers
{
    public class FormManager : ManagerBase<Form>
    {
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

        private UserManager _userManager;


        /// <summary>
        /// Initializes a new instance of the FormManager class.
        /// </summary>
        /// <param name="persistentStorage"></param>
        public FormManager(IPersistentStorage persistentStorage)
            : base(persistentStorage)
        {
            _userManager = new UserManager(_persistentStorage);
        }


        public Form GetForm(string userEmail, int id)
        {
            User user = _userManager.GetUser(userEmail);
            Form result = GetSingle(f => f.ID == id);

            bool isOwner = (result.AuthorID == user.ID);
            if (!isOwner && !_userManager.GetUserPermissions(userEmail).Form_List)
                throw new PermissionException("Form_List");

            return result;
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

        public IQueryable<FormType> GetFormTypes()
        {
            return Context.FormType;
        }
        public IQueryable<QuestionGroupType> GetQuestionGroupTypes()
        {
            return Context.QuestionGroupType;
        }

    }
}
