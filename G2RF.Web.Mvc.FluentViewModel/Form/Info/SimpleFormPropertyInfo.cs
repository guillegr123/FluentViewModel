using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Form.Validation;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Info
{
    public class SimpleFormPropertyInfo
    {
        public HtmlEditorType EditorType { protected internal set; get; }
        public string TemplateName { protected internal set; get; }
        public string Label { protected internal set; get; }
        public string Name { protected internal set; get; }
        public int Length { protected internal set; get; }
        public int MultilineRows { protected internal set; get; }
        public string Format { protected internal set; get; }
        public ValidatorPositionEnum ValidatorPosition { protected internal set; get; }
        public UInt16 FieldOrder { protected internal set; get; }
        public Func<object, object, bool> CanDisplayEditor { protected internal set; get; }
        public Func<object, object, bool> CanEditEditor { protected internal set; get; }

        public SimpleFormPropertyInfo()
        {
            MultilineRows = 1;
        }

        public SimpleFormPropertyInfo(SimpleFormPropertyInfo sfpinfo)
        {
            Name = sfpinfo.Name;
            EditorType = sfpinfo.EditorType;
            TemplateName = sfpinfo.TemplateName;
            Label = sfpinfo.Label;
            Length = sfpinfo.Length;
            ValidatorPosition = sfpinfo.ValidatorPosition;
            FieldOrder = sfpinfo.FieldOrder;
            CanDisplayEditor = sfpinfo.CanDisplayEditor;
            MultilineRows = sfpinfo.MultilineRows;
            Format = sfpinfo.Format;
            CanEditEditor = sfpinfo.CanEditEditor;
        }
    }
}
