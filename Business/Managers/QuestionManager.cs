using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Storages;

namespace ELearning.Business.Managers
{
    public class QuestionManager : ManagerBase<Question>
    {
        /// <summary>
        /// Initializes a new instance of the QuestionManager class.
        /// </summary>
        /// <param name="persistentStorage"></param>
        public QuestionManager(IPersistentStorage persistentStorage)
            : base(persistentStorage)
        {
            
        }


        public Question GetQuestion(int id)
        {
            return GetSingle(q => q.ID == id);
        }
    }
}
