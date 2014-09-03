using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using G2RF.Web.Mvc.FluentViewModel.Form.Buttons;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Info
{
    public class FormInfo
    {
        public string CssClass { set; get; }

        //public string HtmlAttributes { set; get; }

        public string SubmitAction { set; get; }

        public string SubmitController { set; get; }

        public string SubmitArea { set; get; }

        public FormMethod FormSubmitMethod { set; get; }

        public bool ShowValidationSummary { set; get; }

        public string Title { set; get; }

        public List<FormButton> Buttons { private set; get; }

        public object HtmlAttributes { set; get; }

        public FormInfo()
        {
            Buttons = new List<FormButton>();
        }
    }
}
