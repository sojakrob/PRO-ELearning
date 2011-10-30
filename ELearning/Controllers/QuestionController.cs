using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Data;

namespace ELearning.Controllers
{   
    public class QuestionController : Controller
    {
        private ELearning.Business.Managers.QuestionManager _questionManager = new Business.Managers.QuestionManager(ELearning.Business.Storages.WebStorage.Instance);
        // TODO Use Unity to inject the dependency

        //
        // GET: /Question/

        public ViewResult Index()
        {
            return View(_questionManager.GetAll());
            //return View(context.Questions.Include(question => question.QuestionGroup).ToList());
        }

        //
        // GET: /Question/Details/5

        public ViewResult Details(int id)
        {
            Question question = _questionManager.GetQuestion(id);
            return View(question);
        }

        ////
        //// GET: /Question/Create

        //public ActionResult Create()
        //{
        //    //ViewBag.PossibleQuestionGroup = context.QuestionGroups;
        //    return View();
        //} 

        ////
        //// POST: /Question/Create

        //[HttpPost]
        //public ActionResult Create(Question question)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Questions.Add(question);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");  
        //    }

        //    //ViewBag.PossibleQuestionGroup = context.QuestionGroups;
        //    return View(question);
        //}
        
        ////
        //// GET: /Question/Edit/5
 
        //public ActionResult Edit(int id)
        //{
        //    Question question = context.Questions.Single(x => x.ID == id);
        //    //ViewBag.PossibleQuestionGroup = context.QuestionGroups;
        //    return View(question);
        //}

        ////
        //// POST: /Question/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Question question)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Entry(question).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    //ViewBag.PossibleQuestionGroup = context.QuestionGroups;
        //    return View(question);
        //}

        ////
        //// GET: /Question/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    Question question = context.Questions.Single(x => x.ID == id);
        //    return View(question);
        //}

        ////
        //// POST: /Question/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Question question = context.Questions.Single(x => x.ID == id);
        //    context.Questions.Remove(question);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}