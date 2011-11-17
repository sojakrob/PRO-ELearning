using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Data;
using ELearning.Models;
using ELearning.Business.Managers;
using ELearning.Business.Storages;
using ELearning.Models.Data;

namespace ELearning.Controllers
{
    [Authorize]
    public class FormController : BaseController
    {
        FormManager _formManager;


        /// <summary>
        /// Initializes a new instance of the FormController class.
        /// </summary>
        /// <param name="formManager"></param>
        public FormController(FormManager formManager)
        {
            _formManager = formManager;
        }


        public ViewResult Index()
        {
            return View(ModelsFromArray<Form, FormModel>(_formManager.GetAll()));
        }

        public ViewResult Details(int id)
        {
            Form form = _formManager.GetForm(id);
            return View(new FormModel(form));
        }

        public ActionResult Create()
        {
            FillViewBag();

            return View();
        }

        [HttpPost]
        public ActionResult Create(FormModel form)
        {
            if (ModelState.IsValid)
            {
                if (_formManager.AddForm(form.ToData()))
                    return RedirectToAction("Index"); // TODO Redirect to adding question groups of created form
            }

            FillViewBag();

            return View(form);
        }

        public ActionResult Edit(int id)
        {
            FillViewBag();

            Form form = _formManager.GetForm(id);

            return View(new FormModel(form));
        }

        [HttpPost]
        public ActionResult Edit(FormModel form)
        {
            if (ModelState.IsValid)
            {
                _formManager.EditForm(form.ToData());
                return RedirectToAction("Index");
            }

            FillViewBag();

            return View(form);
        }


        private void FillViewBag()
        {
            ViewBag.FormTypes = ModelsFromArray<FormType, FormTypeModel>(_formManager.GetFormTypes());
            ViewBag.DefaultFormType = _formManager.DefaultFormTypeID;
        }

        ////
        //// GET: /Form/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    Form form = context.Form.Single(x => x.ID == id);
        //    return View(form);
        //}

        ////
        //// POST: /Form/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Form form = context.Form.Single(x => x.ID == id);
        //    context.Form.Remove(form);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        
    }
}