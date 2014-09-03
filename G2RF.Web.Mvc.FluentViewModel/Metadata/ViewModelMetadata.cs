using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using G2RF.Web.Mvc.FluentViewModel.Form.Validation;
using System.ComponentModel.DataAnnotations;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;

namespace G2RF.Web.Mvc.FluentViewModel.Metadata
{
    public class ViewModelMetadata : ViewModelMetadataBase
    {
        public ViewModelMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<System.Object> modelAccessor, Type modelType, string propertyName, System.ComponentModel.DataAnnotations.DisplayColumnAttribute displayColumnAttribute, SimpleFormPropertyInfo infoProp)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute)
        {
            TemplateHint = infoProp.TemplateName ?? infoProp.EditorType.ToString();
            DisplayName = infoProp.Label;
            ShowForEdit = true;

            EditorType = infoProp.EditorType;
            Length = infoProp.Length;
            ValidatorPosition = infoProp.ValidatorPosition;
            Order = infoProp.FieldOrder;
            CanDisplayEditor = infoProp.CanDisplayEditor;
            MultilineRows = infoProp.MultilineRows;
            DisplayFormatString = infoProp.Format;
            EditFormatString = infoProp.Format;
        }

        public ViewModelMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<System.Object> modelAccessor, Type modelType, string propertyName, DisplayColumnAttribute displayColumnAttribute)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute)
        {
            
        }
        public int MultilineRows { protected internal set; get; }
        public int Length { protected internal set; get; }
        public ValidatorPositionEnum ValidatorPosition { protected internal set; get; }
        //public UInt16 Order { protected internal set; get; }
        public Func<object, object, bool> CanDisplayEditor { protected internal set; get; }
    }
}
