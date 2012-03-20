using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Data.Enums;
using System.ComponentModel.DataAnnotations;
using ELearning.Utils;

namespace ELearning.Models.Data
{
    public class FormModel : DataModelBase<Form>
    {
        private const int TEXT_MAX_LENGTH = 20;



        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Text { get; set; }
        public string TextCropped
        {
            get { return Utils.Formatting.CropText(Text, TEXT_MAX_LENGTH); }
        }

        [Display(Name = "Shuffle Questions")]
        public bool Shuffle { get; set; }

        /// <summary>
        /// Time to fill in minutes
        /// </summary>
        public int? TimeToFill { get; set; }

        public DateTime Created { get; set; }

        public FormTypeModel Type { get; set; }
        public FormStateModel State { get; set; }

        public int? MaxFills { get; set; }

        public UserModel Author { get; set; }

        public List<QuestionGroupModel> QuestionGroups { get; set; }

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

        /// <summary>
        /// Gets number of times the form was filled
        /// </summary>
        public int TimesFilled_Total { get; private set; }
        /// <summary>
        /// Gets number of users that filled the form
        /// </summary>
        public int TimesFilled_Users { get; private set; }


        /// <summary>
        /// Initializes a new instance of the FormModel class.
        /// </summary>
        /// <param name="form"></param>
        public FormModel()
        {
            _assignedGroupsData = new List<Group>();
        }
        public FormModel(Form data)
            : base(data)
        {
            if (data == null)
                throw new ArgumentNullException();

            ID = data.ID;
            Name = data.Name;
            Text = data.Text;
            Created = data.Created;
            Shuffle = data.Shuffle;
            MaxFills = data.MaxFills;

            if(data.TimeToFill != null)
                TimeToFill = Conversion.SecondsToMinutes(data.TimeToFill.Value);

            if (data.Type == null)
                Type = new FormTypeModel();
            else
                Type = new FormTypeModel(data.Type);

            if (data.State == null)
                State = new FormStateModel();
            else
                State = new FormStateModel(data.State);

            if (data.Author == null)
                Author = new UserModel();
            else
                Author = new UserModel(data.Author);

            QuestionGroups = DataModelBase<QuestionGroup>.CreateFromArray<QuestionGroupModel>(data.QuestionGroups);

            _assignedGroupsData = data.Groups;

            CountTimesFilled(data);
        }


        private void CountTimesFilled(Form data)
        {
            TimesFilled_Total = data.FormInstances.Count(f => !f.IsPreview);
            TimesFilled_Users = data.FormInstances.Where(f => !f.IsPreview).GroupBy(f => f.SolverID).Count();
        }


        public override Form ToData()
        {
            Form result = Form.CreateForm(
                ID,
                Name,
                Created,
                Type == null ? 0 : Type.ID,
                Author == null ? 0 : Author.ID,
                State == null ? 0 : State.ID
                );
            result.Text = Text;
            result.Shuffle = Shuffle;
            result.MaxFills = MaxFills;

            if(TimeToFill != null)
                result.TimeToFill = Conversion.MinutesToSeconds(TimeToFill.Value);

            return result;
        }
    }
}