using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using G2RF.Web.Mvc.FluentViewModel.Common;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    public class DateTimeEditorPart : EditorBasePart
    {
        protected readonly DateTimeFormPropertyInfo _FormPropertyInfo;

        public DateTimeEditorPart(SimpleKeyValue<string, SimpleFormPropertyInfo> propertyNode)
            : base(propertyNode)
        {
            _PropertyNode.Value = _FormPropertyInfo
                = new DateTimeFormPropertyInfo(propertyNode.Value);
        }

        public void DateFormat(string dateFormat)
        {
            _FormPropertyInfo.DateFormat = dateFormat;
        }
    }
}
