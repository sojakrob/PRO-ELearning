﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Business.Managers;
using ELearning.Models;
using ELearning.Data;
using ELearning.Models.Data;
using ELearning.Authentication;
using ELearning.Data.Enums;

namespace ELearning.Controllers
{
    [Authorize]
    public class StudentController : BaseController
    {
        private UserManager _userManager;
        private FormManager _formManager;


        /// <summary>
        /// Initializes a new instance of the StudentController class.
        /// </summary>
        /// <param name="userManager"></param>
        public StudentController(UserManager userManager, FormManager formManager)
        {
            _userManager = userManager;
            _formManager = formManager;
        }


        [AuthorizeUserType(UserType = UserTypes.Lector)]
        public ActionResult Index()
        {
            var students = _userManager.GetStudents();
            var studentModels = ModelsFromArray<User, UserModel>(students);

            return View(studentModels);
        }

        public ActionResult Detail(int id)
        {
            var student = _userManager.GetStudent(id);
            var filledForms = _formManager.GetFormInstances(student.Email);

            FillDefaultViewBag();

            return View(new StudentFormsModel(student, filledForms));
        }
    }
}
