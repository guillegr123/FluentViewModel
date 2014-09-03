using System;
using System.Collections.Generic;
using System.Linq;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Info
{
    public class RangeFormPropertyInfo : SimpleFormPropertyInfo
    {
        public int MinValue { protected internal set; get; }
        public int MaxValue { protected internal set; get; }

        public RangeFormPropertyInfo(SimpleFormPropertyInfo sfpinfo) : base(sfpinfo)
        {
        }
    }
}
