using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using G2RF.Web.Mvc.FluentViewModel.Common;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    public class TextEditorPart : EditorBasePart
    {
        public TextEditorPart(SimpleKeyValue<string, SimpleFormPropertyInfo> propertyNode)
            : base(propertyNode)
        {
        }

        public void Length(int length)
        {
            _PropertyNode.Value.Length = length;
        }

        public TextEditorPart Multiline(int rows)
        {
            _PropertyNode.Value.MultilineRows = rows;
            return this;
        }
    }
}
