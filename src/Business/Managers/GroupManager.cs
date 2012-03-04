using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Storages;
using ELearning.Business.Permissions;
using ELearning.Business.Exceptions;

namespace ELearning.Business.Managers
{
    public class GroupManager : ManagerBase<Group>
    {
        private UserManager _userManager;
        private FormManager _formManager;


        /// <summary>
        /// Initializes a new instance of the GroupManager class.
        /// </summary>
        /// <param name="persistentStorage"></param>
        public GroupManager(IPersistentStorage persistentStorage, IPermissionsProvider permissionsProvider)
            : base(persistentStorage, permissionsProvider)
        {
            _userManager = new UserManager(_persistentStorage, permissionsProvider);
            _formManager = new FormManager(_persistentStorage, permissionsProvider);
        }


        public override IQueryable<Group> GetAll()
        {
            // TODO Permissions
            return base.GetAll();
        }

        public static Group GetNewGroupInstance(int id, string name, int supervisorID)
        {
            return Group.CreateGroup(
                id,
                name,
                supervisorID
                );
        }
        public bool CreateGroup(string name, int supervisorID)
        {
            if (!Permissions.Group_CreateEdit)
                throw new PermissionException("Group_CreateEdit");

            Context.Group.AddObject(
                GetNewGroupInstance(
                    0,
                    name,
                    supervisorID
                    )
                );
            Context.SaveChanges();

            return true;
        }
        public Group GetGroup(int id)
        {
            // TODO Permissions

            return Context.Group.Where(g => g.ID == id).FirstOrDefault();
        }

        public IEnumerable<User> GetPossibleMembersFor(int groupID)
        {
            var group = GetGroup(groupID);
            var result = _userManager.GetAll().ToList();

            result.Remove(group.Supervisor);
            foreach (var member in group.Members)
                result.Remove(member);

            return result;
        }

        public IEnumerable<Group> GetPossibleGroupsFor(int formID)
        {
            var form = _formManager.GetForm(formID);
            var groups = GetAll().ToList();
            foreach (var assignedGroup in form.Groups)
            {
                groups.Remove(assignedGroup);
            }
            return groups;
        }

        public bool AssignUser(int userID, int groupID)
        {
            // TODO Permissions

            try
            {
                var group = GetGroup(groupID);
                var user = _userManager.GetUser(userID);

                group.Members.Add(user);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO Log exception   
                return false;
            }

            return true;
        }

        public IEnumerable<Group> GetUserGroups(int userID)
        {
            var user = _userManager.GetUser(userID);
            var groups = GetAll().Where(g => g.Members.Contains(user));
            return groups;
        }
    }
}
