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
using ELearning.Authentication;
using ELearning.Data.Enums;

namespace ELearning.Controllers
{
    [AuthorizeUserType(UserType = UserTypes.Administrator)]
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


        [AuthorizeUserType(UserType = UserTypes.Administrator)]
        public ViewResult Index()
        {
            return View(ModelsFromArray<User, UserModel>(_userManager.GetAll()));
        }

        [AuthorizeUserType(UserType = UserTypes.Administrator)]
        public ViewResult Details(int id)
        {
            
            return View();
        }

        [AuthorizeUserType(UserType = UserTypes.Administrator)]
        public ActionResult Create()
        {
            FillViewBag();

            return View();
        } 
        [HttpPost]
        [AuthorizeUserType(UserType = UserTypes.Administrator)]
        public ActionResult Create(NewUserModel user)
        {
            if (ModelState.IsValid)
            {
                bool userCreated = _userManager.CreateUser(user.Email, user.Password, user.Type.ID);
                if(userCreated)
                    return RedirectToAction("Index");
            }

            FillViewBag();

            return View(user);
        }

        [AuthorizeUserType(UserType = UserTypes.Administrator)]
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        [AuthorizeUserType(UserType = UserTypes.Administrator)]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
            }

            return View(user);
        }

        [AuthorizeUserType(UserType = UserTypes.Administrator)]
        public ActionResult Delete(string email)
        {
            if (_userManager.DeleteUser(AuthenticationContext.LoggedUserSession.Email, email))
                return RedirectToAction("Index");

            // TODO Confirm deletion

            return View();
        }
        [HttpPost, ActionName("Delete")]
        [AuthorizeUserType(UserType = UserTypes.Administrator)]
        public ActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }


        private void FillViewBag()
        {
            ViewBag.UserTypes = ModelsFromArray<UserType, UserTypeModel>(_userManager.GetUserTypes());
            ViewBag.DefaultUserType = _userManager.DefaultUserTypeID;
        }
    }
}