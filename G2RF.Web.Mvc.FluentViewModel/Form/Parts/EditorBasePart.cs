using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using G2RF.Web.Mvc.FluentViewModel.Common;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    public abstract class EditorBasePart
    {
        protected internal SimpleKeyValue<string, SimpleFormPropertyInfo> _PropertyNode;

        public EditorBasePart(SimpleKeyValue<string, SimpleFormPropertyInfo> propertyNode)
        {
            _PropertyNode = propertyNode;
        }
    }
}
