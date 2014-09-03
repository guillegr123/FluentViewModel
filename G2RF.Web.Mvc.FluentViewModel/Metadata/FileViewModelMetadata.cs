using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace G2RF.Web.Mvc.FluentViewModel.Metadata
{
    public class FileViewModelMetadata : ViewModelMetadata
    {
        public string[] AcceptedFileExtensions { protected internal set; get; }
        public int MaxSizeBytes { protected internal set; get; }

        public FileViewModelMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<System.Object> modelAccessor, Type modelType, string propertyName, DisplayColumnAttribute displayColumnAttribute, FileFormPropertyInfo infoProp)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute, infoProp)
        {
            AcceptedFileExtensions = infoProp.AcceptedFileExtensions.ToArray();
        }

        public FileViewModelMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<System.Object> modelAccessor, Type modelType, string propertyName, DisplayColumnAttribute displayColumnAttribute)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute)
        {
            
        }
    }
}
