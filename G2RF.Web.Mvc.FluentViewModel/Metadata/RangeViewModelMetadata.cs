using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;

namespace G2RF.Web.Mvc.FluentViewModel.Metadata
{
    public class RangeViewModelMetadata : ViewModelMetadata
    {
        public int MinValue { protected internal set; get; }
        public int MaxValue { protected internal set; get; }

        public RangeViewModelMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<System.Object> modelAccessor, Type modelType, string propertyName, System.ComponentModel.DataAnnotations.DisplayColumnAttribute displayColumnAttribute, RangeFormPropertyInfo infoProp)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute, infoProp)
        {
            MinValue = infoProp.MinValue;
            MaxValue = infoProp.MaxValue;
        }

        public RangeViewModelMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<System.Object> modelAccessor, Type modelType, string propertyName, DisplayColumnAttribute displayColumnAttribute)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute)
        {
            
        }
    }
}
