using System;
using System.Collections.Generic;
using FluentValidation;
using System.Web.Mvc;
using System.ComponentModel;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Mapping;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using G2RF.Web.Mvc.FluentViewModel.Form;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Mvc;
using FluentValidation.Validators;

namespace G2RF.Web.Mvc.FluentViewModel.Metadata.Providers
{
    public class ConditionalPropertyEditorDisplay
    {
        public Func<object, object, bool> FuncCanDisplayEditor;
        public object PropertyValue;

        public ConditionalPropertyEditorDisplay()
        {
        }

        public bool CanDisplayEditor(object model)
        {
            return FuncCanDisplayEditor(model, PropertyValue);
        }
    }

    public class FluentViewModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly IValidatorFactory _Factory;

        //private Dictionary<string, ViewModelMetadataBase> _ModelsMetadata;

        public FluentViewModelMetadataProvider(IValidatorFactory factory)
        {
            _Factory = factory;
            //_ModelsMetadata = new Dictionary<string, ViewModelMetadataBase>();
        }

        //public override IEnumerable<ModelMetadata> GetMetadataForProperties(object container, Type containerType)
        //{
        //    return base.GetMetadataForProperties(container, containerType);
        //}

        public override IEnumerable<ModelMetadata> GetMetadataForProperties(object container, Type containerType)
        {
            if (containerType == null)
            {
                throw new ArgumentNullException("containerType");
            }

            return GetMetadataForPropertiesImpl(container, containerType);
        }

        private IEnumerable<ModelMetadata> GetMetadataForPropertiesImpl(object container, Type containerType)
        {
            var propertiesMetadata = new List<ModelMetadata>();
            foreach (PropertyDescriptor property in GetTypeDescriptor(containerType).GetProperties())
            {
                Func<object> modelAccessor = container == null ? null : GetPropertyValueAccessor(container, property);
                //yield return GetMetadataForProperty(modelAccessor, containerType, property);
                propertiesMetadata.Add(GetMetadataForProperty(modelAccessor, containerType, property));
            }
            return propertiesMetadata.Where(x => x != null).OrderBy(x => ((ViewModelMetadata)x).Order);
        }

        private static Func<object> GetPropertyValueAccessor(object container, PropertyDescriptor property)
        {
            return () => property.GetValue(container);
        }

        //public override ModelMetadata GetMetadataForType(Func<object> modelAccessor, Type modelType)
        //{
        //    //ViewModelMetadataBase vMMetadata;
        //    //if (_ModelsMetadata.TryGetValue(modelType.FullName, out vMMetadata))
        //    //{
        //    //    return vMMetadata;
        //    //}

        //    var metadata = base.GetMetadataForType(modelAccessor, modelType);

        //    // Modificando metadatos de acuerdo a mapa
        //    var mapa = (IViewModelMap)_Factory.GetValidator(modelType);

        //    // Retornando metadatos
        //    return metadata;
        //}

        //public override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, string propertyName)
        //{
        //    // Intentar obtener metadatos de caché. Si no están, crear metadatos.
        //    ViewModelMetadataBase metadata = null;
        //    if (_ModelsMetadata.TryGetValue(containerType.FullName, out metadata) && metadata.IsPropertiesMetadataLoaded)
        //    {
        //        metadata = (ViewModelMetadataBase)metadata.Properties.FirstOrDefault(x => x.PropertyName.Equals(propertyName));
        //        if (metadata != null)
        //        {
        //            return ((ViewModelMetadata)metadata).Clone(modelAccessor);
        //        }
        //    }
        //    return base.GetMetadataForProperty(modelAccessor, containerType, propertyName);
        //}

        //protected override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, PropertyDescriptor propertyDescriptor)
        //{
        //    // Intentar obtener metadatos de caché. Si no están, crear metadatos.
        //    ViewModelMetadataBase metadata = null;
        //    if (_ModelsMetadata.TryGetValue(containerType.FullName, out metadata) && metadata.IsPropertiesMetadataLoaded)
        //    {
        //        metadata = (ViewModelMetadataBase)metadata.Properties.FirstOrDefault(x => x.PropertyName.Equals(propertyDescriptor.Name));
        //        if (metadata != null)
        //        {
        //            return ((ViewModelMetadata)metadata).Clone(modelAccessor);
        //        }
        //    }
        //    return base.GetMetadataForProperty(modelAccessor, containerType, propertyDescriptor);
        //}

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            // The next is almost the same of MVC2 DataAnnotationsModelMetadataProvider
            List<Attribute> attributeList = new List<Attribute>(attributes);

            DisplayColumnAttribute displayColumnAttribute = attributeList.OfType<DisplayColumnAttribute>().FirstOrDefault();

            #region Modified1

            // The ModelMetadata type changes depending on the type of the HtmlEditor
            ViewModelMetadataBase result = null;

            // Setting metadata according to ViewModelMap, if exists
            IViewModelMap vmmap = null;
            bool existsVM = true;

            if (containerType != null)
            {
                vmmap = (IViewModelMap)_Factory.GetValidator(containerType);
                var originalContainerType = containerType;
                while (vmmap == null && (containerType = containerType.BaseType) != null)   // If map is not found, search for maps of base types
                {
                    vmmap = (IViewModelMap)_Factory.GetValidator(containerType);
                }
                if (vmmap == null)
                {
                    containerType = originalContainerType;
                }
                else
                //if (vmmap != null)
                {
                    if (propertyName == null)
                    {
                        result = new MainViewModelMetadata(this, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute, vmmap.GetFormInfo());
                    }
                    else
                    {
                        var infoProp = vmmap.GetPropertyFormInfo(propertyName);

                        if (infoProp != null)
                        {
                            if ((infoProp.EditorType & (HtmlEditorType.RadioButtonGroup | HtmlEditorType.SimpleDropDownList | HtmlEditorType.SimpleTabularDropDownList | HtmlEditorType.MultiCheckBoxList)) != 0)
                            {
                                result = new ListViewModelMetadata(this, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute, (ListFormPropertyInfo)infoProp);
                            }
                            else if (infoProp.EditorType == HtmlEditorType.Spinner)
                            {
                                result = new RangeViewModelMetadata(this, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute, (RangeFormPropertyInfo)infoProp);
                            }
                            else if (infoProp.EditorType == HtmlEditorType.Upload)
                            {
                                result = new FileViewModelMetadata(this, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute, (FileFormPropertyInfo)infoProp);
                            }
                            else
                            {
                                result = new ViewModelMetadata(this, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute, infoProp);
                            }
                        }
                        else
                        {
                            return null;
                        }

                        // Adding attributes according to validators defined through FluentValidation (Based on FluentValidation's FluentValidationModelMetadataProvider class) >>>>>
                        var validators = vmmap.CreateDescriptor().GetValidatorsForMember(propertyName);

                        attributeList = /*validators.OfType<IAttributeMetadataValidator>()
                            .Select(x => x.ToAttribute())
                            .Concat(*/ SpecialCaseValidatorConversions(validators).ToList() /*)*/
                            .Union(attributeList).ToList();
                        // <<<<<
                    }
                }
            }
            else
            {
                vmmap = (IViewModelMap)_Factory.GetValidator(modelType);
                var originalModelType = modelType;
                while (vmmap == null && (modelType = modelType.BaseType) != null)   // If map is not found, search for maps of base types
                {
                    vmmap = (IViewModelMap)_Factory.GetValidator(modelType);
                }
                if (vmmap == null)
                {
                    modelType = originalModelType;
                }
                else
                //if (vmmap != null)
                {
                    result = new MainViewModelMetadata(this, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute, vmmap.GetFormInfo());
                }
            }

            if (result == null)
            {
                existsVM = false;
                result = new ViewModelMetadata(this, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute);
            }

            if (!existsVM)
            {
                // Do [HiddenInput] before [UIHint], so you can override the template hint
                HiddenInputAttribute hiddenInputAttribute = attributeList.OfType<HiddenInputAttribute>().FirstOrDefault();
                if (hiddenInputAttribute != null)
                {
                    result.TemplateHint = "HiddenInput";
                    result.HideSurroundingHtml = !hiddenInputAttribute.DisplayValue;
                }

                // We prefer [UIHint("...", PresentationLayer = "MVC")] but will fall back to [UIHint("...")]
                IEnumerable<UIHintAttribute> uiHintAttributes = attributeList.OfType<UIHintAttribute>();
                UIHintAttribute uiHintAttribute = uiHintAttributes.FirstOrDefault(a => String.Equals(a.PresentationLayer, "MVC", StringComparison.OrdinalIgnoreCase))
                                               ?? uiHintAttributes.FirstOrDefault(a => String.IsNullOrEmpty(a.PresentationLayer));
                if (uiHintAttribute != null)
                {
                    result.TemplateHint = uiHintAttribute.UIHint;
                }
            }
            #endregion

            DataTypeAttribute dataTypeAttribute = attributeList.OfType<DataTypeAttribute>().FirstOrDefault();
            if (dataTypeAttribute != null)
            {
                result.DataTypeName = dataTypeAttribute.GetDataTypeName();
            }

            ReadOnlyAttribute readOnlyAttribute = attributeList.OfType<ReadOnlyAttribute>().FirstOrDefault();
            if (readOnlyAttribute != null)
            {
                result.IsReadOnly = readOnlyAttribute.IsReadOnly;
            }

            DisplayFormatAttribute displayFormatAttribute = attributeList.OfType<DisplayFormatAttribute>().FirstOrDefault();
            if (displayFormatAttribute == null && dataTypeAttribute != null)
            {
                displayFormatAttribute = dataTypeAttribute.DisplayFormat;
            }
            if (displayFormatAttribute != null)
            {
                result.NullDisplayText = displayFormatAttribute.NullDisplayText;
                result.DisplayFormatString = displayFormatAttribute.DataFormatString;
                result.ConvertEmptyStringToNull = displayFormatAttribute.ConvertEmptyStringToNull;

                if (displayFormatAttribute.ApplyFormatInEditMode)
                {
                    result.EditFormatString = displayFormatAttribute.DataFormatString;
                }
            }

            ScaffoldColumnAttribute scaffoldColumnAttribute = attributeList.OfType<ScaffoldColumnAttribute>().FirstOrDefault();
            if (scaffoldColumnAttribute != null)
            {
                result.ShowForDisplay = result.ShowForEdit = scaffoldColumnAttribute.Scaffold;
            }

            #region Modified3
            if (!existsVM || ((ViewModelMetadataBase)result).DisplayName == null)
            {
                DisplayNameAttribute displayNameAttribute = attributeList.OfType<DisplayNameAttribute>().FirstOrDefault();
                if (displayNameAttribute != null)
                {
                    result.DisplayName = displayNameAttribute.DisplayName;
                }
            }
            #endregion

            RequiredAttribute requiredAttribute = attributeList.OfType<RequiredAttribute>().FirstOrDefault();
            if (requiredAttribute != null)
            {
                result.IsRequired = true;
            }

            //#region Modified4
            //if (containerType == null)
            //{
            //    //Agregando a listado de metadatos
            //    _ModelsMetadata.Add(modelType.FullName, result);
            //}
            //#endregion

            return result;
        }


        #region From FluentValidation's FluentValidationModelMetadataProvider class
        static IEnumerable<Attribute> SpecialCaseValidatorConversions(IEnumerable<IPropertyValidator> validators)
        {

            //Email Validator should be convertible to DataType EmailAddress.
            var emailValidators = validators
                .OfType<IEmailValidator>()
                .Select(x => new DataTypeAttribute(DataType.EmailAddress))
                .Cast<Attribute>();

            var requiredValidators = validators.OfType<INotNullValidator>().Cast<IPropertyValidator>()
                .Concat(validators.OfType<INotEmptyValidator>().Cast<IPropertyValidator>())
                .Select(x => new RequiredAttribute())
                .Cast<Attribute>();

            return requiredValidators.Concat(emailValidators);
        }
        #endregion
    }

    //public class FluentViewModelMetadataProvider : DataAnnotationsModelMetadataProvider
    //    //: FluentValidationModelMetadataProvider 
    //{
    //    //private readonly AdministradorVistas _AdminVistas;
    //    //protected readonly IValidatorFactory _Fabrica;

    //    //public FluentViewModelMetadataProvider(IValidatorFactory factory)
    //    //{
    //    //    _Fabrica = factory;
    //    //    //_AdminVistas = new AdministradorVistas(10);
    //    //}

    //    private readonly IValidatorFactory _Factory;

    //    public FluentViewModelMetadataProvider(IValidatorFactory factory)
    //    {
    //        _Factory = factory;
    //    }

    //    protected override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, PropertyDescriptor propertyDescriptor) {
    //        // Obteniendo metadatos de forma predeterminada
    //        ModelMetadata metadatos = base.GetMetadataForProperty(modelAccessor, containerType, propertyDescriptor);
    //            //CreateMetadata(attributes, containerType, modelAccessor, propertyDescriptor.PropertyType, propertyDescriptor.Name);
            
    //        // Modificando metadatos de acuerdo a mapa
    //        var mapa = (IViewModelMap)_Factory.GetValidator(containerType);

    //        if (mapa != null)
    //        {
    //            var infoProp = mapa.GetPropertyFormInfo(propertyDescriptor.Name);

    //            if (infoProp != null)
    //            {
    //                metadatos.TemplateHint = infoProp.EditorType.ToString();
    //                metadatos.DisplayName = infoProp.Label;
    //                metadatos.ShowForEdit = true;
    //                metadatos.AdditionalValues["I"] = infoProp;  //Validator Position
    //                if (infoProp.CanDisplayEditor != null)
    //                {
    //                    metadatos.AdditionalValues["V"] = new ConditionalPropertyEditorDisplay() { FuncCanDisplayEditor = infoProp.CanDisplayEditor, PropertyValue = modelAccessor() };
    //                }
    //            }
    //            else
    //            {
    //                metadatos.ShowForEdit = false;
    //            }
    //        }

    //        // Retornando metadatos
    //        return metadatos;
    //    }

    //    public override ModelMetadata GetMetadataForType(Func<object> modelAccessor, Type modelType)
    //    {
    //        // Obteniendo metadatos de forma predeterminada
    //        ModelMetadata metadatos = base.GetMetadataForType(modelAccessor, modelType);

    //        // Modificando metadatos de acuerdo a mapa
    //        var mapa = (IViewModelMap)_Factory.GetValidator(modelType);

    //        if (mapa != null)
    //        {
    //            metadatos.AdditionalValues["I"] = mapa.GetFormInfo();
    //        }

    //        // Retornando metadatos
    //        return metadatos;
    //    }

    //    protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
    //    {
    //        return base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
    //    }

    //    public override IEnumerable<ModelMetadata> GetMetadataForProperties(object container, Type containerType)
    //    {
    //        var metadataForProperties = base.GetMetadataForProperties(container, containerType);
    //        if (metadataForProperties != null)
    //        {
    //            object condObj;
    //            //IEnumerable<ModelMetadata> displayableMetadata = metadataForProperties.Where(x => x.ShowForEdit && x.AdditionalValues.ContainsKey("V"));
    //            foreach (var propmetadata in metadataForProperties)
    //            {
    //                condObj = null;
    //                if (propmetadata.ShowForEdit && propmetadata.AdditionalValues.TryGetValue("V", out condObj))
    //                {
    //                    var valor = ((ConditionalPropertyEditorDisplay)condObj).CanDisplayEditor(container);
    //                    propmetadata.ShowForEdit = valor;
    //                    if (!valor)
    //                    {
    //                        propmetadata.AdditionalValues.Remove("I");
    //                    }
    //                }
    //                propmetadata.AdditionalValues.Remove("V");
    //            }

    //            return metadataForProperties
    //                    .Where(x => x.AdditionalValues.ContainsKey("I"))
    //                    .OrderBy(x => ((SimpleFormPropertyInfo)x.AdditionalValues["I"]).FieldOrder);
    //        }
    //        return metadataForProperties;
    //    }
    //}
}
