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
    public class TextBookLinkManager : ManagerBase<TextBookLink>
    {

        public TextBookLinkManager(IPersistentStorage persistentStorage, ManagersContainer container, ELearning.Business.Interfaces.IIdentityProvider permissionsProvider)
            : base(persistentStorage, container, permissionsProvider)
        {
        }

        public TextBookLink getTextBookLinkById(int textBookLinkID)
        {
            return Context.TextBookLink.Single(t => t.ID == textBookLinkID);
        }
        public IEnumerable<TextBookLink> getTextBookLinkByHName(string textBookLinkHName)
        {
            return Context.TextBookLink.Where(t => t.HName == textBookLinkHName);
        }
        public IEnumerable<TextBookLink> getTextBookLinkByTextBookId(int textBookID)
        {
            return null;
        }
        public IEnumerable<TextBookLink> getTextBookLinkByQuestionId(int questionID)
        {
            return null;
        }

        public static TextBookLink CreateTextBookQuestionLink(int textBookID, int questionID, string hName)
        {
            return TextBookLink.CreateTextBookLink(DEFAULT_ID, hName, textBookID, questionID);
        }
    }
}
