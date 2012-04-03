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


        public GroupManager(IPersistentStorage persistentStorage, ManagersContainer container, IPermissionsProvider permissionsProvider)
            : base(persistentStorage, container,  permissionsProvider)
        {
            _userManager = new UserManager(_persistentStorage, container, permissionsProvider);
            _formManager = new FormManager(_persistentStorage, container, permissionsProvider);
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

        public override IQueryable<Group> GetAll()
        {
            if(Permissions.Group_List_All)
                return base.GetAll();

            return GetUserGroups();
        }
        public IQueryable<Group> GetUserGroups()
        {
            return Context.Group.Where(
                g =>
                    g.SupervisorID == PermissionsProvider.UserID
                    || g.Members.Count(m => m.ID == PermissionsProvider.UserID) > 0
                );
        }
        public Group GetGroup(int id)
        {
            Group result = Context.Group.Where(g => g.ID == id).FirstOrDefault();
            if (result == null)
                throw new ArgumentException("Group not found");

            if (Permissions.Group_List_All)
                return result;

            if (result.SupervisorID != PermissionsProvider.UserID
                && result.Members.Count(m => m.ID == PermissionsProvider.UserID) == 0)
            {
                throw new PermissionException("Group_Get");
            }

            return result;
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

        public IEnumerable<Group> GetPossibleGroupsForForm(int formID)
        {
            var form = _formManager.GetForm(formID);
            return GetGroupsNotIn(form.Groups);
        }
        public IEnumerable<Group> GetPossibleGroupsForTextBook(int textBookID)
        {
            var textBook = _managers.Get<TextBookManager>().GetTextBook(textBookID);
            return GetGroupsNotIn(textBook.Groups);
        }
        private List<Group> GetGroupsNotIn(IEnumerable<Group> groups)
        {
            var allGroups = GetAll().ToList();
            foreach (var assignedGroup in groups)
                allGroups.Remove(assignedGroup);

            return allGroups;
        }

        public bool AssignUser(int userID, int groupID)
        {
            if (!Permissions.Group_CreateEdit)
                throw new PermissionException("Group_CreateEdit");

            var group = GetGroup(groupID);
            var user = _userManager.GetUser(userID);

            try
            {
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
        public void SetGroupMembers(int groupID, int[] memberIDs)
        {
            if (!Permissions.Group_CreateEdit)
                throw new PermissionException("Group_CreateEdit");

            var group = GetGroup(groupID);

            try
            {
                var memberIDsToAdd = memberIDs.ToList();
                var membersToRemove = new List<User>();
                foreach (var member in group.Members)
                {
                    if (memberIDsToAdd.Contains(member.ID))
                        memberIDsToAdd.Remove(member.ID);
                    else
                        membersToRemove.Add(member);
                }
                foreach (User member in membersToRemove)
                    group.Members.Remove(member);
                foreach (var memberID in memberIDsToAdd)
                    group.Members.Add(_userManager.GetUser(memberID));

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO Log exception
            }
        }


        public IEnumerable<Group> GetGroupsWhereIsMember(int userID)
        {
            var groups = GetAll().Where(g => g.Members.Count(m => m.ID == PermissionsProvider.UserID) > 0);
            return groups;
        }

        public static Group GetNewGroupInstance(int id, string name, int supervisorID)
        {
            return Group.CreateGroup(
                id,
                name,
                supervisorID
                );
        }

    }
}
