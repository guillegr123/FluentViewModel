using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Common;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    public class EditorPart<TProperty> : EditorBasePart
    {
        public EditorPart(SimpleKeyValue<string, SimpleFormPropertyInfo> propertyNode) : base(propertyNode)
        {
        }

        public EditorPart<TProperty> UsingEditorTemplate(string templateName)
        {
            _PropertyNode.Value.TemplateName = templateName;
            return this;
        }

        public TextEditorPart AsTextBox()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.TextBox;
            return new TextEditorPart(_PropertyNode);
        }

        public TextEditorPart AsPassword()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.Password;
            return new TextEditorPart(_PropertyNode);
        }

        public void AsCheckBox()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.CheckBox;
            //return new SimpleEditorPart<TModel>(_PropertyNode);
        }

        public void AsHidden()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.Hidden;
            //return new PropiedadFormSimplePart<T>(propertyNode);
        }

        public DateTimeEditorPart AsDate()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.Date;
            return new DateTimeEditorPart(_PropertyNode);
        }

        public SimpleListEditorPart<TProperty> AsDropDownList()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.SimpleDropDownList;
            return new SimpleListEditorPart<TProperty>(_PropertyNode);
        }

        public SimpleListEditorPart<TDropDown> AsDropDownListOfType<TDropDown>()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.SimpleDropDownList;
            return new SimpleListEditorPart<TDropDown>(_PropertyNode);
        }

        public SimpleListEditorPart<TListItem> AsMultiSelectCheckBoxListOfType<TListItem>()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.MultiCheckBoxList;
            return new SimpleListEditorPart<TListItem>(_PropertyNode);
        }

        public SimpleListEditorPart<TProperty> AsRadioButtonGroup()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.RadioButtonGroup;
            return new SimpleListEditorPart<TProperty>(_PropertyNode);
        }

        public SimpleListEditorPart<TDropDown> AsRadioButtonGroupOfType<TDropDown>()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.RadioButtonGroup;
            return new SimpleListEditorPart<TDropDown>(_PropertyNode);
        }

        public SimpleTabularListEditorPart<TProperty> AsTabularDropDownList()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.SimpleTabularDropDownList;
            return new SimpleTabularListEditorPart<TProperty>(_PropertyNode);
        }

        public SimpleTabularListEditorPart<TDropDown> AsTabularDropDownListOfType<TDropDown>()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.SimpleTabularDropDownList;
            return new SimpleTabularListEditorPart<TDropDown>(_PropertyNode);
        }

        public RangeEditorPart AsSpinner()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.Spinner;
            return new RangeEditorPart(_PropertyNode);
        }

        public void AsEmbeddedForm()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.EmbeddedForm;
        }

        public void AsMergedForm()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.MergedForm;
        }

        public FileEditorPart AsUpload()
        {
            _PropertyNode.Value.EditorType = HtmlEditorType.Upload;
            return new FileEditorPart(_PropertyNode);
        }
    }
}
