using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ELearning.Data;
using ELearning.Business.Permissions;
using ELearning.Business.Storages;
using ELearning.Business.Exceptions;

namespace ELearning.Business.Managers
{
    public class TextBookManager : ManagerBase<TextBook>
    {
        public TextBookManager(IPersistentStorage persistentStorage, ManagersContainer container, IPermissionsProvider permissionsProvider)
            : base(persistentStorage, container, permissionsProvider)
        {
            
        }


        public override TextBook GetSingle(System.Linq.Expressions.Expression<Func<TextBook, bool>> predicate)
        {
            return GetAll().SingleOrDefault(predicate);
        }
        public TextBook GetTextBook(int textBookID)
        {
            return GetSingle(t => t.ID == textBookID);
        }

        public override IQueryable<TextBook> GetAll()
        {
            KickAnonymous();

            if (Permissions.TextBook_List)
                return Context.TextBook;

            var groups = _managers.Get<GroupManager>().GetUserGroups();

            var visibleTextBooks = from g in groups
                                   from t in g.TextBooks
                                   where t.VisibleToOthers
                                   select t;
            var usersTextBooks = Context.TextBook.Where(t => t.CreatedBy.ID == PermissionsProvider.UserID);
            var textBooks = visibleTextBooks.Union(usersTextBooks);

            return textBooks;
        }

        public int AddTextBook(TextBook textBook)
        {
            if (textBook == null)
                throw new ArgumentNullException("TextBook");

            if (!Permissions.TextBook_CreateEdit)
                throw new PermissionException("TextBook_CreateEdit");

            textBook.CreatedByID = PermissionsProvider.UserID;
            textBook.Created = DateTime.Now;
            textBook.ChangedByID = PermissionsProvider.UserID;
            textBook.Changed = DateTime.Now;
            textBook.Html = BuildTextBookHtml(textBook.Text);

            try
            {
                Context.TextBook.AddObject(textBook);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO Log exception
                return -1;
            }

            return textBook.ID;
        }

        public bool EditTextbook(TextBook textBook)
        {
            TextBook trueTextBook = GetTextBook(textBook.ID);

            // TODO Check edit permissions

            trueTextBook.Title = textBook.Title;
            trueTextBook.Text = textBook.Text;
            trueTextBook.Html = BuildTextBookHtml(textBook.Text);
            trueTextBook.VisibleToOthers = textBook.VisibleToOthers;
            trueTextBook.ChangedByID = PermissionsProvider.UserID;
            trueTextBook.Changed = DateTime.Now;

            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                // TODO Log exception
                return false;
            }

            return true;
        }
        public void SetTextBookAssignedGroups(int textBookID, int[] groupIDs)
        {
            // TODO Refactor with FormManager.SetFormAssignedGroups?
            if (groupIDs == null)
                return;

            var groupIDsToAdd = groupIDs.ToList();
            var textBook = GetTextBook(textBookID);
            var textBookGroups = textBook.Groups.ToList();
            foreach (var group in textBookGroups)
            {
                if (groupIDsToAdd.Contains(group.ID))
                    groupIDsToAdd.Remove(group.ID);
                else
                    textBook.Groups.Remove(group);
            }
            foreach (var groupID in groupIDsToAdd)
                textBook.Groups.Add(_managers.Get<GroupManager>().GetGroup(groupID));

            Context.SaveChanges();
        }

        private string BuildTextBookHtml(string text)
        {
            return new ProjectBase.Tools.Wiki.WikiConverter().ConvertToHtml(text);
        }


        public static TextBook CreateNewTextBook(string title, string text)
        {
            return TextBook.CreateTextBook(
                DEFAULT_ID,
                DateTime.Now,
                DateTime.Now,
                title,
                text,
                DEFAULT_ID,
                DEFAULT_ID,
                string.Empty
                );
        }

    }
}
