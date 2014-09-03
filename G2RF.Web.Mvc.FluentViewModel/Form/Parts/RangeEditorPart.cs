using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using G2RF.Web.Mvc.FluentViewModel.Common;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    public class RangeEditorPart : TextEditorPart
    {
        protected readonly RangeFormPropertyInfo _FormPropertyInfo;

        public RangeEditorPart(SimpleKeyValue<string, SimpleFormPropertyInfo> propertyNode)
            : base(propertyNode)
        {
            _PropertyNode.Value = _FormPropertyInfo = new RangeFormPropertyInfo(propertyNode.Value);
        }

        public RangeEditorPart MinValue(int minValue)
        {
            _FormPropertyInfo.MinValue = minValue;
            return this;
        }

        public RangeEditorPart MaxValue(int maxValue)
        {
            _FormPropertyInfo.MaxValue = maxValue;
            return this;
        }

        public RangeEditorPart Format(string format)
        {
            _FormPropertyInfo.Format = format;
            return this;
        }
    }
}
