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


        //
        // GET: /Form/

        public ViewResult Index()
        {
            return View(ModelsFromArray<Form, FormModel>(_formManager.GetAll()));
        }

        //
        // GET: /Form/Details/5

        public ViewResult Details(int id)
        {
            Form form = _formManager.GetForm(id);
            return View(new FormModel(form));
        }

        //
        // GET: /Form/Create

        public ActionResult Create()
        {
            ViewBag.FormTypes = ModelsFromArray<FormType, FormTypeModel>(_formManager.GetFormTypes());
            ViewBag.DefaultFormType = _formManager.DefaultFormType;

            return View();
        }

        //
        // POST: /Form/Create

        [HttpPost]
        public ActionResult Create(FormModel form)
        {
            if (ModelState.IsValid)
            {
                if(_formManager.AddForm(form.ToData()))
                    return RedirectToAction("Index"); // TODO Redirect to adding question groups of created form
            }

            ViewBag.FormTypes = ModelsFromArray<FormType, FormTypeModel>(_formManager.GetFormTypes());
            ViewBag.DefaultFormType = _formManager.DefaultFormType;

            return View(form);
        }

        //
        // GET: /Form/Edit/5

        public ActionResult Edit(int id)
        {
            Form form = _formManager.GetForm(id);

            ViewBag.FormTypes = ModelsFromArray<FormType, FormTypeModel>(_formManager.GetFormTypes());
            ViewBag.DefaultFormType = _formManager.DefaultFormType;

            return View(new FormModel(form));
        }

        //
        // POST: /Form/Edit/5

        [HttpPost]
        public ActionResult Edit(FormModel form)
        {
            if (ModelState.IsValid)
            {
                _formManager.EditForm(form.ToData());
                return RedirectToAction("Index");
            }

            ViewBag.FormTypes = ModelsFromArray<FormType, FormTypeModel>(_formManager.GetFormTypes());
            ViewBag.DefaultFormType = _formManager.DefaultFormType;

            return View(form);
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