using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Business.Managers;
using System.ComponentModel.DataAnnotations;

namespace ELearning.Models.Data
{
    public class TextBookModel : DataModelBase<TextBook>
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayLocalized("Title")]
        public string Title { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
        public DateTime Changed { get; set; }

        [DisplayLocalized("VisibleToOthers")]
        public bool VisibleToOthers { get; set; }

        public UserModel CreatedBy { get; private set; }

        public IEnumerable<GroupModel> AssignedGroups
        {
            get
            {
                if (_assignedGroups == null)
                    _assignedGroups = GroupModel.CreateFromArray<GroupModel>(_assignedGroupsData);
                return _assignedGroups;
            }
            set { _assignedGroups = value; }
        }
        private IEnumerable<GroupModel> _assignedGroups = null;
        private IEnumerable<Group> _assignedGroupsData;

        public IEnumerable<TextBookLinkModel> TextBookLinks { 
            get
            {
                if (_assignedTextBookLinks == null)
                    _assignedTextBookLinks = TextBookLinkModel.CreateFromArray<TextBookLinkModel>(_assignedTextBookLinksData);
                return _assignedTextBookLinks;
            } 
            set
            {
                _assignedTextBookLinks = value;
            } 
        }
        private IEnumerable<TextBookLinkModel> _assignedTextBookLinks = null;
        private IEnumerable<TextBookLink> _assignedTextBookLinksData;

        public TextBookModel()
        {
            _assignedGroups = new List<GroupModel>();
            _assignedTextBookLinks = new List<TextBookLinkModel>();
        }
        public TextBookModel(TextBook data)
            : base(data)
        {
            ID = data.ID;
            Title = data.Title;
            Text = data.Text;
            Html = data.Html;
            VisibleToOthers = data.VisibleToOthers;
            Changed = data.Changed;
            CreatedBy = new UserModel(data.CreatedBy);
            _assignedGroupsData = data.Groups;
            _assignedTextBookLinksData = data.TextBookLink;
        }


        public override TextBook ToData()
        {
            if (Text == null)
                Text = string.Empty;

            var result = TextBookManager.CreateNewTextBook(
                Title,
                Text
                );

            result.ID = ID;
            result.Text = result.Text.Replace("&lt;", "<").Replace("&gt;", ">");
            result.VisibleToOthers = VisibleToOthers;

            return result;
        }
    }
}