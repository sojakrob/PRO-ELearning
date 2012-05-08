using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Models;
using ELearning.Business.Managers;
using ELearning.Data;
using ELearning.Models.Data;

namespace ELearning.Controllers
{
    public class HomeController : BaseController
    {
        private FormManager _formManager;
        private TextBookManager _textBookManager;


        /// <summary>
        /// Initializes a new instance of the HomeController class.
        /// </summary>
        public HomeController(FormManager formManager, TextBookManager textBookManager)
        {
            _formManager = formManager;
            _textBookManager = textBookManager;
        }


        public ActionResult Index()
        {
            if (AuthenticationContext.IsUserLoggedIn)
                return RedirectToAction("Home");

            return View();
        }



        public ActionResult Home()
        {
            if (!AuthenticationContext.IsUserLoggedIn)
                return RedirectToLogOn();


            
            var formFills = ModelsFromArray<Form, FormFillsModel>(_formManager.GetNotArchivedForms(), _formManager);
            var textBooks = ModelsFromArray<TextBook, TextBookModel>(_textBookManager.GetAll().OrderByDescending(t => t.Changed));
            
            var model = new HomePageModel(formFills, textBooks);

            return View(model);
        }
    }
}
