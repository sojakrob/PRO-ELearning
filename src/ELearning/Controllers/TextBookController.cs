using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Authentication;
using ELearning.Data.Enums;
using ELearning.Data;
using ELearning.Models.Data;
using ELearning.Business.Managers;

namespace ELearning.Controllers
{
    [Authorize]
    public class TextBookController : BaseController
    {
        private TextBookManager _textBookManager;
        private GroupManager _groupManager;


        public TextBookController(TextBookManager textBookManager, GroupManager groupManager)
        {
            _textBookManager = textBookManager;
            _groupManager = groupManager;
        }


        [AuthorizeUserType(UserType=UserTypes.Student)]
        public ActionResult Index()
        {
            var textBooks = ModelsFromArray<TextBook, TextBookModel>(_textBookManager.GetAll());
            return View(textBooks);
        }

        [AuthorizeUserType(UserType = UserTypes.Student)]
        public ActionResult Create()
        {
            var model = new NewTextBookModel();
            model.PossibleGroups = GroupModel.CreateFromArray<GroupModel>(_groupManager.GetAll());
            return View(model);
        }
        [HttpPost]
        [AuthorizeUserType(UserType = UserTypes.Student)]
        public ActionResult Create(NewTextBookModel textBook, int[] assignedGroupIDs)
        {
            if (ModelState.IsValid)
            {
                int textBookID = _textBookManager.AddTextBook(textBook.ToData());
                if (textBookID != -1)
                {
                    if (assignedGroupIDs == null)
                        assignedGroupIDs = new int[] { };
                    _textBookManager.SetTextBookAssignedGroups(textBookID, assignedGroupIDs);

                    return RedirectToAction("Index");
                }
            }

            textBook.PossibleGroups = GroupModel.CreateFromArray<GroupModel>(_groupManager.GetAll());

            return View(textBook);
        }

        [AuthorizeUserType(UserType = UserTypes.Student)]
        public ActionResult Edit(int id)
        {
            var textBook = _textBookManager.GetTextBook(id);
            return View(new NewTextBookModel(textBook, _groupManager.GetPossibleGroupsForTextBook(id)));
        }
        [HttpPost]
        [AuthorizeUserType(UserType = UserTypes.Student)]
        public ActionResult Edit(NewTextBookModel textBook, int[] assignedGroupIDs)
        {
            if (ModelState.IsValid)
            {
                _textBookManager.EditTextbook(textBook.ToData());

                if (assignedGroupIDs == null)
                    assignedGroupIDs = new int[] { };
                _textBookManager.SetTextBookAssignedGroups(textBook.ID, assignedGroupIDs);

                return RedirectToAction("Index");
            }

            textBook.PossibleGroups = GroupModel.CreateFromArray<GroupModel>(_groupManager.GetAll());
            
            return View(textBook);
        }

        [AuthorizeUserType(UserType=UserTypes.Student)]
        public ActionResult View(int id)
        {
            var textBook = _textBookManager.GetTextBook(id);
            return View(new TextBookModel(textBook));
        }
    }
}
