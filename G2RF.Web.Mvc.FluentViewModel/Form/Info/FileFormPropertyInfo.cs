using System;
using System.Collections.Generic;
using System.Linq;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Info
{
    public class FileFormPropertyInfo : SimpleFormPropertyInfo
    {
        public List<string> AcceptedFileExtensions { set; get; }
        public int MaxSizeBytes { set; get; }

        public FileFormPropertyInfo(SimpleFormPropertyInfo sfpinfo)
            : base(sfpinfo)
        {
        }
    }
}
