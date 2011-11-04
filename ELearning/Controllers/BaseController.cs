using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Models.Data;
using ELearning.Business.Storages;

namespace ELearning.Controllers
{
    public class BaseController : Controller
    {


        protected ICollection<Model> ModelsFromArray<Data, Model>(IEnumerable<Data> array)
            where Data : class
            where Model : DataModelBase<Data>
        {
            return DataModelBase<Data>.CreateFromArray<Model>(array);
        }
    }
}
