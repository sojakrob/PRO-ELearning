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


        /// <summary>
        /// Initializes a new instance of the FormManager class.
        /// </summary>
        /// <param name="persistentStorage"></param>
        public FormManager(IPersistentStorage persistentStorage)
            : base(persistentStorage)
        {

        }


        public Form GetForm(int id)
        {
            return GetSingle(f => f.ID == id);
        }

        public bool AddForm(string authorEmail, Form form)
        {
            UserManager userManager = new UserManager(_persistentStorage);

            if (!userManager.GetUserPermissions(authorEmail).Form_CreateEdit)
                throw new PermissionException("Form_CreateEdit");

            User author = userManager.GetUser(authorEmail);

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
                return false;
            }

            return true;
        }

        public bool EditForm(Form form)
        {
            Form trueForm = GetForm(form.ID);

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

        public IQueryable<FormType> GetFormTypes()
        {
            return Context.FormType;
        }

    }
}
