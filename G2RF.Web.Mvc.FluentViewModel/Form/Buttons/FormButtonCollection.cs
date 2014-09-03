using System;
using System.Collections.Generic;
using System.Linq;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Buttons
{
    public class FormButtonCollection
    {
        internal List<FormButton> Botones { private set; get; }

        public FormButtonCollection()
        {
            Botones = new List<FormButton>();
        }

        public FormButtonCollection Add(FormButton boton)
        {
            Botones.Add(boton);
            return this;
        }
    }
}
