using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;
using ELearning.Models.Data;
using ELearning.Business.Managers;

namespace ELearning.Models
{
    public class FormFillsModel : Data.FormModel
    {
        private FormManager _formManager;

        public IEnumerable<FormInstanceFillModel> FormInstances
        {
            get
            {
                if (_formInstances == null)
                    _formInstances = DataModelBase<FormInstance>.CreateFromArray<FormInstanceFillModel>(_formManager.GetFormInstances(_formID));
                return _formInstances;
            }            
        }
        private IEnumerable<FormInstanceFillModel> _formInstances;
        private int _formID;


        /// <summary>
        /// Initializes a new instance of the FormFillsModel class.
        /// </summary>
        /// <param name="form"></param>
        public FormFillsModel()
        {
            
        }
        public FormFillsModel(Form data, FormManager formManager)
            : base(data)
        {
            //FormInstances = DataModelBase<FormInstance>.CreateFromArray<FormInstanceFillModel>(data.FormInstances.Where(f => !f.IsPreview));
            _formManager = formManager;
            _formID = data.ID;
        }
        


    }
}