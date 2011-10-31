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
        public int GetDefaultFormType()
        {
            return 2;
            // TODO Load from global settings
        }
    }
}
