using System;
using System.Collections.Generic;
using System.Linq;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Info
{
    public class DateTimeFormPropertyInfo : SimpleFormPropertyInfo
    {
        public string DateFormat { set; get; }

        public DateTimeFormPropertyInfo(SimpleFormPropertyInfo sfpinfo)
            : base(sfpinfo)
        {
        }
    }
}
