using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using G2RF.Web.Mvc.FluentViewModel.Form;
//using System.Diagnostics.CodeAnalysis;

namespace G2RF.Web.Mvc.FluentViewModel.Metadata
{
    public abstract class ViewModelMetadataBase : DataAnnotationsModelMetadata
    {
        private bool _showForEdit;
        public override bool ShowForEdit
        {
            get
            {
                return _showForEdit;
            }
            set
            {
                _showForEdit = value;
            }
        }

        public HtmlEditorType EditorType { protected internal set; get; }

        public ViewModelMetadataBase(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<System.Object> modelAccessor, Type modelType, string propertyName, System.ComponentModel.DataAnnotations.DisplayColumnAttribute displayColumnAttribute)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute)
        {
            EditorType = HtmlEditorType.Undefined;
            _showForEdit = true;
        }

        //private IEnumerable<ModelMetadata> _properties;
        //public override IEnumerable<ModelMetadata> Properties
        //{
        //    get
        //    {
        //        if (_properties == null)
        //        {
        //            _properties = Provider.GetMetadataForProperties(Model, RealModelType);
        //            _IsPropertiesMetadataLoaded = true;
        //        }
        //        return _properties;
        //    }
        //}

        //private bool _IsPropertiesMetadataLoaded = false;
        //public bool IsPropertiesMetadataLoaded
        //{
        //    get { return _IsPropertiesMetadataLoaded; }
        //}

        //public void SetProperties(IEnumerable<ModelMetadata> properties)
        //{
        //    _properties = properties;
        //    _IsPropertiesMetadataLoaded = true;
        //}

        //private Type _realModelType;
        //internal Type RealModelType
        //{
        //    get
        //    {
        //        if (_realModelType == null)
        //        {
        //            _realModelType = ModelType;

        //            // Don't call GetType() if the model is Nullable<T>, because it will
        //            // turn Nullable<T> into T for non-null values
        //            if (Model != null && Nullable.GetUnderlyingType(ModelType) == null)
        //            {
        //                _realModelType = Model.GetType();
        //            }
        //        }

        //        return _realModelType;
        //    }
        //}

        //#region Borrar
        //private static ModelMetadata FromModel(ViewDataDictionary viewData)
        //{
        //    return viewData.ModelMetadata ?? GetMetadataFromProvider(null, typeof(string), null, null);
        //}

        //public static ModelMetadata FromStringExpression(string expression, ViewDataDictionary viewData)
        //{
        //    //Trying to get metadata from ViewData first
        //    if (expression == null)
        //    {
        //        throw new ArgumentNullException("expression");
        //    }
        //    if (viewData == null)
        //    {
        //        throw new ArgumentNullException("viewData");
        //    }
        //    if (expression.Length == 0)
        //    {    // Empty string really means "model metadata for the current model"
        //        return FromModel(viewData);
        //    }
        //    Type containerType = null;
        //    Type modelType = null;
        //    Func<object> modelAccessor = null;
        //    string propertyName = null;


        //    //Giving priority to the existing metadata in ViewData
        //    if (viewData.ModelMetadata != null)
        //    {
        //        ModelMetadata propertyMetadata = viewData.ModelMetadata.Properties.Where(p => p.PropertyName == expression).FirstOrDefault();
        //        if (propertyMetadata != null)
        //        {
        //            return propertyMetadata;
        //        }
        //    }
            
        //    ViewDataInfo vdi = viewData.GetViewDataInfo(expression);
        //    if (vdi != null)
        //    {
        //        if (vdi.Container != null)
        //        {
        //            containerType = vdi.Container.GetType();
        //        }

        //        modelAccessor = () => vdi.Value;

        //        if (vdi.PropertyDescriptor != null)
        //        {
        //            propertyName = vdi.PropertyDescriptor.Name;
        //            modelType = vdi.PropertyDescriptor.PropertyType;
        //        }
        //        else if (vdi.Value != null)
        //        {  // We only need to delay accessing properties (for LINQ to SQL)
        //            modelType = vdi.Value.GetType();
        //        }
        //    }

        //    return GetMetadataFromProvider(modelAccessor, modelType ?? typeof(string), propertyName, containerType);
        //}

        //[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "The method is a delegating helper to choose among multiple property values")]
        //public string GetDisplayName()
        //{
        //    return DisplayName ?? PropertyName ?? ModelType.Name;
        //}

        //private static ModelMetadata GetMetadataFromProvider(Func<object> modelAccessor, Type modelType, string propertyName, Type containerType)
        //{
        //    if (containerType != null && !String.IsNullOrEmpty(propertyName))
        //    {
        //        return ModelMetadataProviders.Current.GetMetadataForProperty(modelAccessor, containerType, propertyName);
        //    }
        //    return ModelMetadataProviders.Current.GetMetadataForType(modelAccessor, modelType);
        //}
        //#endregion
    }
}
