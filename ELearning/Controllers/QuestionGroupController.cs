using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Data;
using ELearning.Models;

namespace ELearning.Controllers
{   
    public class QuestionGroupController : Controller
    {
        //private ELearningContext context = new ELearningContext();

        ////
        //// GET: /QuestionGroup/

        //public ViewResult Index()
        //{
        //    return View(context.QuestionGroups.Include(questiongroup => questiongroup.Questions).ToList());
        //}

        ////
        //// GET: /QuestionGroup/Details/5

        //public ViewResult Details(int id)
        //{
        //    QuestionGroup questiongroup = context.QuestionGroup.Single(x => x.ID == id);
        //    return View(questiongroup);
        //}

        ////
        //// GET: /QuestionGroup/Create

        //public ActionResult Create()
        //{
        //    ViewBag.PossibleQuestionGroupType = context.QuestionGroupType;
        //    return View();
        //} 

        ////
        //// POST: /QuestionGroup/Create

        //[HttpPost]
        //public ActionResult Create(QuestionGroup questiongroup)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.QuestionGroup.Add(questiongroup);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");  
        //    }

        //    ViewBag.PossibleQuestionGroupType = context.QuestionGroupType;
        //    return View(questiongroup);
        //}
        
        ////
        //// GET: /QuestionGroup/Edit/5
 
        //public ActionResult Edit(int id)
        //{
        //    QuestionGroup questiongroup = context.QuestionGroup.Single(x => x.ID == id);
        //    ViewBag.PossibleQuestionGroupType = context.QuestionGroupType;
        //    return View(questiongroup);
        //}

        ////
        //// POST: /QuestionGroup/Edit/5

        //[HttpPost]
        //public ActionResult Edit(QuestionGroup questiongroup)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Entry(questiongroup).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.PossibleQuestionGroupType = context.QuestionGroupType;
        //    return View(questiongroup);
        //}

        ////
        //// GET: /QuestionGroup/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    QuestionGroup questiongroup = context.QuestionGroup.Single(x => x.ID == id);
        //    return View(questiongroup);
        //}

        ////
        //// POST: /QuestionGroup/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    QuestionGroup questiongroup = context.QuestionGroup.Single(x => x.ID == id);
        //    context.QuestionGroup.Remove(questiongroup);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}