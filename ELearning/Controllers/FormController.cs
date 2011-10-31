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

namespace ELearning.Controllers
{   
    public class FormController : Controller
    {
        private FormManager _formManager = new FormManager(WebStorage.Instance);

        //
        // GET: /Form/

        public ViewResult Index()
        {
            return View(_formManager.GetAll());
        }

        //
        // GET: /Form/Details/5

        public ViewResult Details(int id)
        {
            Form form = _formManager.GetForm(id);
            return View(form);
        }

        //
        // GET: /Form/Create

        public ActionResult Create()
        {
            ViewBag.FormTypes = _formManager.GetFormTypes();
            ViewBag.DefaultFormType = _formManager.GetDefaultFormType();
            return View();
        }

        //
        // POST: /Form/Create

        [HttpPost]
        public ActionResult Create(Form form)
        {
            if (ModelState.IsValid)
            {
                if(_formManager.AddForm(form))
                    return RedirectToAction("Index"); // TODO Redirect to adding question groups of created form
            }

            ViewBag.FormTypes = _formManager.GetFormTypes();
            //ViewBag.PossibleFormType = context.FormType;
            //ViewBag.PossibleAuthor = context.User;
            return View(form);
        }
        
        ////
        //// GET: /Form/Edit/5
 
        //public ActionResult Edit(int id)
        //{
        //    Form form = context.Form.Single(x => x.ID == id);
        //    ViewBag.PossibleFormType = context.FormType;
        //    ViewBag.PossibleAuthor = context.User;
        //    return View(form);
        //}

        ////
        //// POST: /Form/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Form form)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Entry(form).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.PossibleFormType = context.FormType;
        //    ViewBag.PossibleAuthor = context.User;
        //    return View(form);
        //}

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