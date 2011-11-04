using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Storages;

namespace ELearning.Business.Managers
{
    public class FormManager : ManagerBase<Form>
    {
        public int DefaultFormType
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

        public bool AddForm(Form form)
        {
            form.AuthorID = 1; // TODO Use current user id
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

            if (!trueForm.Name.Equals(form.Name))
                trueForm.Name = form.Name;
            if (!trueForm.Text.Equals(form.Text))
                trueForm.Text = form.Text;
            if (!trueForm.FormTypeID.Equals(form.FormTypeID))
                trueForm.FormTypeID = form.FormTypeID;
            if (!trueForm.Shuffle.Equals(form.Shuffle))
                trueForm.Shuffle = form.Shuffle;
            if (!trueForm.TimeToFill.Equals(form.TimeToFill))
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
