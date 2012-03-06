using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELearning.Business.Managers;
using ELearning.Data;
using ELearning.Models.Data;

namespace ELearning.Controllers
{
    [Authorize]
    public class GroupController : BaseController
    {
        GroupManager _groupManager;
        UserManager _userManager;


        /// <summary>
        /// Initializes a new instance of the GroupController class.
        /// </summary>
        /// <param name="groupManager"></param>
        public GroupController(GroupManager groupManager, UserManager userManager)
        {
            _groupManager = groupManager;
            _userManager = userManager;
        }


        public ActionResult Index()
        {
            FillDefaultViewBag();

            return View(ModelsFromArray<Group, GroupModel>(_groupManager.GetAll()));
        }

        public ActionResult Create()
        {
            IQueryable<User> lectors = _userManager.GetLectors();
            var model = new NewGroupModel(lectors);

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(NewGroupModel group)
        {
            if (ModelState.IsValid)
            {
                bool created = _groupManager.CreateGroup(
                    group.Name,
                    group.SupervisorID
                    );
                if (created)
                    return RedirectToAction("Index");
            }

            //FillViewBag();

            NewGroupModel model = new NewGroupModel(_userManager.GetLectors());
            model.Name = group.Name;
            model.SupervisorID = group.SupervisorID;

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var members = _groupManager.GetPossibleMembersFor(id);
            var group = new EditGroupModel(_groupManager.GetGroup(id), ModelsFromArray<User, UserModel>(members));

            FillDefaultViewBag();

            return View(group);
        }
        [HttpPost]
        public ActionResult Edit(int groupID, int[] assignedMemberIDs)
        {
            if (assignedMemberIDs == null)
                assignedMemberIDs = new int[] { };

            _groupManager.SetGroupMembers(groupID, assignedMemberIDs);

            var possibleMembers = _groupManager.GetPossibleMembersFor(groupID);
            var group = new EditGroupModel(_groupManager.GetGroup(groupID), ModelsFromArray<User, UserModel>(possibleMembers));

            FillDefaultViewBag();

            return View(group);
        }

        public ActionResult AssignMember(int memberID, int groupID)
        {
            _groupManager.AssignUser(memberID, groupID);

            return RedirectToAction("Edit", new { id = groupID });
        }
    }
}
