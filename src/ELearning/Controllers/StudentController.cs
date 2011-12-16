using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Business.Managers;
using ELearning.Models;
using ELearning.Data;

namespace ELearning.Controllers
{
    [Authorize]
    public class StudentController : BaseController
    {
        private UserManager _userManager;


        /// <summary>
        /// Initializes a new instance of the StudentController class.
        /// </summary>
        /// <param name="userManager"></param>
        public StudentController(UserManager userManager)
        {
            _userManager = userManager;
        }


        public ActionResult Index()
        {
            var students = _userManager.GetStudents(CurrentLoggedUserModel.Email);
            var studentModels = ModelsFromArray<User, StudentModel>(students);

            return View(studentModels);
        }

        public ActionResult Detail(int id)
        {
            var student = _userManager.GetStudent(CurrentLoggedUserModel.Email, id);

            return View(new StudentModel(student));
        }
    }
}
