using System;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Buttons
{
    public enum ButtonBehaviorEnum { None = 0, Click = 1, Submit = 2, Save = 3, Cancel = 4 }

    public class FormButton
    {
        public string Name { set; get; }

        public string Text { set; get; }

        public ButtonBehaviorEnum Behavior { set; get; }

        public string OnClick { set; get; }
    }
}
