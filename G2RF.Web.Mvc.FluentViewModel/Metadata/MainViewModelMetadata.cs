using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Form.Buttons;
using System.Web.Mvc;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;

namespace G2RF.Web.Mvc.FluentViewModel.Metadata
{
    public class MainViewModelMetadata : ViewModelMetadataBase
    {
        public MainViewModelMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<System.Object> modelAccessor, Type modelType, string propertyName, System.ComponentModel.DataAnnotations.DisplayColumnAttribute displayColumnAttribute)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute)
        {
            
        }

        public MainViewModelMetadata(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<System.Object> modelAccessor, Type modelType, string propertyName, System.ComponentModel.DataAnnotations.DisplayColumnAttribute displayColumnAttribute, FormInfo formInfo)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute)
        {
            CssClass = formInfo.CssClass;
            SubmitAction = formInfo.SubmitAction;
            SubmitController = formInfo.SubmitController;
            SubmitArea = formInfo.SubmitArea;
            FormSubmitMethod = formInfo.FormSubmitMethod;
            ShowValidationSummary = formInfo.ShowValidationSummary;
            Title = formInfo.Title;
            Buttons = formInfo.Buttons;
            HtmlAttributes = formInfo.HtmlAttributes;
        }
        
        public string CssClass { set; get; }

        public string SubmitAction { set; get; }

        public string SubmitController { set; get; }

        public string SubmitArea { set; get; }

        public FormMethod FormSubmitMethod { set; get; }

        public bool ShowValidationSummary { set; get; }

        public string Title { set; get; }

        public List<FormButton> Buttons { private set; get; }

        public object HtmlAttributes { set; get; }
    }
}
