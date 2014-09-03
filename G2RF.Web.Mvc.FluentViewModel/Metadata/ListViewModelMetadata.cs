using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using G2RF.Web.Mvc.FluentViewModel.Common;
using System.Collections;

namespace G2RF.Web.Mvc.FluentViewModel.Metadata
{
    public class ListViewModelMetadata : ViewModelMetadata
    {
        public string ValueField { protected internal set; get; }

        public string DisplayField { protected internal set; get; }

        public string TextFormat { protected internal set; get; }

        public IList<string> DependentFields { protected internal set; get; }

        public string DependsOnField { protected internal set; get; }

        private IEnumerable _StaticOptions;
        protected internal IEnumerable StaticOptions
        {
            set
            {
                _StaticOptions = value;
                if (value != null)
                {
                    GetOptions = GetStaticOptions;
                }
            }
            get
            {
                return _StaticOptions;
            }
        }

        public Func<ViewDataDictionary, IEnumerable> GetOptions { protected internal set; get; }

        /// <summary>
        /// Gets the list of columns to show, in the case of tabular list editors.
        /// The key is the column's name, and the value is the property or column name to be displayed.
        /// </summary>
        public IEnumerable<SimpleKeyValue<string, string>> Columns { internal set; get; }


        //public ListViewModelMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<System.Object> modelAccessor, Type modelType, string propertyName, System.ComponentModel.DataAnnotations.DisplayColumnAttribute displayColumnAttribute)
        //    : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute)
        //{

        //}

        public ListViewModelMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<System.Object> modelAccessor, Type modelType, string propertyName, DisplayColumnAttribute displayColumnAttribute, ListFormPropertyInfo infoProp)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute, infoProp)
        {
            ValueField = infoProp.ValueField;
            DisplayField = infoProp.DisplayField;
            Columns = infoProp.Columns;
            TextFormat = infoProp.TextFormat;
            DependentFields = infoProp.DependentFields;
            DependsOnField = infoProp.DependsOnField;
            if (infoProp.GetOptions != null)
            {
                GetOptions = infoProp.GetOptions;
            }
            else
            {
                StaticOptions = infoProp.StaticOptions;
            }
        }

        public ListViewModelMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<System.Object> modelAccessor, Type modelType, string propertyName, DisplayColumnAttribute displayColumnAttribute)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute)
        {
            
        }

        private IEnumerable GetStaticOptions(ViewDataDictionary vd)
        {
            return _StaticOptions;
        }
    }
}
