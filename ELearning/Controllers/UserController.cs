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
using ELearning.Models.Data;

namespace ELearning.Controllers
{   
    [Authorize]
    public class UserController : BaseController
    {
        UserManager _userManager;


        /// <summary>
        /// Initializes a new instance of the UserController class.
        /// </summary>
        /// <param name="userManager"></param>
        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }


        //
        // GET: /User/
        
        public ViewResult Index()
        {
            return View(ModelsFromArray<User, UserModel>(_userManager.GetAll()));
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(int id)
        {
            
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
            }

            return View(user);
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
            }

            return View(user);
        }

        //
        // GET: /User/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }
    }
}