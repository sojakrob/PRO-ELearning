using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Business.Managers;
using ELearning.Models.Data;
using ELearning.Data;

namespace ELearning.Controllers
{
    public class FormInstanceController : BaseController
    {
        FormManager _formManager;


        /// <summary>
        /// Initializes a new instance of the FormInstanceController class.
        /// </summary>
        /// <param name="formManager"></param>
        public FormInstanceController(FormManager formManager)
        {
            _formManager = formManager;
        }



        public ActionResult Index(int id)
        {
            ELearning.Models.FormInstancesModel model = new ELearning.Models.FormInstancesModel(
                new FormModel(_formManager.GetForm(CurrentLoggedUserModel.Email, id)), 
                ModelsFromArray<FormInstance, FormInstanceModel>(_formManager.GetFormInstances(CurrentLoggedUserModel.Email, id))
                );

            return View(model);
        }

        public ActionResult FillForm(int id)
        {
            FormInstanceModel formInstance = new FormInstanceModel(_formManager.GenerateNewFormInstance(CurrentLoggedUserModel.Email, id));
            return View(formInstance);
        }

        public ActionResult EndForm()
        {
            return View();
        }
    }
}
