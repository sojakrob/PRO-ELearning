using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Storages;
using ELearning.Business.Permissions;

namespace ELearning.Business.Managers
{
    public class GroupManager : ManagerBase<Group>
    {
        private UserManager _userManager;


        /// <summary>
        /// Initializes a new instance of the GroupManager class.
        /// </summary>
        /// <param name="persistentStorage"></param>
        public GroupManager(IPersistentStorage persistentStorage)
            : base(persistentStorage)
        {
            _userManager = new UserManager(_persistentStorage);
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
            // TODO Permissions

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
            foreach (var member in group.Members)
                result.Remove(member);

            return result;
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
