using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using G2RF.Extensions.Linq.Expressions;
using G2RF.Web.Mvc.FluentViewModel.Form.Buttons;
using G2RF.Web.Mvc.FluentViewModel.Form.Parts;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using FluentValidation;
using System.Web.Mvc;
using G2RF.Web.Mvc.FluentViewModel.Common;

namespace G2RF.Web.Mvc.FluentViewModel.Mapping
{
    public abstract class ViewModelMap<TModel> : AbstractValidator<TModel>, IViewModelMap
    {
        private readonly List<SimpleKeyValue<string, SimpleFormPropertyInfo>> _PropertiesInfo;

        private UInt16 _OrdenCampo = 1;

        //protected FormButtonCollection Buttons { private set; get; }

        private FormInfo _FormInformation = null;
        private FormInfo FormInformation
        {
            get
            {
                if (_FormInformation == null)
                {
                    _FormInformation = new FormInfo();
                }
                return _FormInformation;
            }
        }

        public ViewModelMap()
        {
            _PropertiesInfo = new List<SimpleKeyValue<string,SimpleFormPropertyInfo>>();
            //Buttons = new FormButtonCollection();

            var formName = String.Format("F_{0}", typeof(TModel).Name);
            FormInformation.HtmlAttributes = new { @id = formName, @name = formName };
        }

        public void AddButton(FormButton button)
        {
            FormInformation.Buttons.Add(button);
        }

        protected FormPropertyPart<TModel, TProperty> MapProperty<TProperty>(Expression<Func<TModel, TProperty>> propertyExpression)
        {
            var nombrePropiedad = propertyExpression.GetPropertyInfo().Name;
            SimpleKeyValue<string, SimpleFormPropertyInfo> nodoPropiedad = new SimpleKeyValue<string, SimpleFormPropertyInfo>(nombrePropiedad, new SimpleFormPropertyInfo() { FieldOrder = _OrdenCampo++ });
            _PropertiesInfo.Add(nodoPropiedad);
            return new FormPropertyPart<TModel, TProperty>(nodoPropiedad, this, propertyExpression);
        }

        public SimpleFormPropertyInfo GetPropertyFormInfo(string nombreProp)
        {
            var info = _PropertiesInfo.FirstOrDefault(x => nombreProp.Equals(x.Key));
            if (info == null)
            {
                return null;
            }
            return info.Value;
        }

        //public IEnumerable<FormButton> GetFormButtons()
        //{
        //    return Buttons.Botones;
        //}

        public FormInfo GetFormInfo()
        {
            //Linking dependent fields
            foreach (var p in _PropertiesInfo.Where(x => x.Value is ListFormPropertyInfo))
            {
                foreach (var df in ((ListFormPropertyInfo)p.Value).DependentFields)
                {
                    var dfProp = _PropertiesInfo.Where(x => x.Value is ListFormPropertyInfo).FirstOrDefault(x => x.Key.Equals(df));
                    if (dfProp != null)
                    {
                        ((ListFormPropertyInfo)dfProp.Value).DependsOnField = p.Key;
                    }
                }
            }

            return FormInformation;
        }

        public void UseFormCssClass(string cssClass)
        {
            FormInformation.CssClass = cssClass;
        }

        public void FormTitle(string title)
        {
            FormInformation.Title = title;
        }

        public void HtmlAttributes(object htmlAttrs)
        {
            FormInformation.HtmlAttributes = htmlAttrs;
        }

        public void ShowValidationSummary()
        {
            FormInformation.ShowValidationSummary = true;
        }

        public SubmitMethodPart FormSubmit(FormMethod method)
        {
            FormInformation.FormSubmitMethod = method;
            return new SubmitMethodPart(FormInformation);
        }

        public List<SimpleKeyValue<string, SimpleFormPropertyInfo>> GetPropertiesInfo()
        {
            return _PropertiesInfo;
        }

        public class SubmitMethodPart
        {
            private FormInfo _Fi;

            public SubmitMethodPart(FormInfo fi)
            {
                _Fi = fi;
            }

            public SubmitActionPart UseAction(string action)
            {
                _Fi.SubmitAction = action;
                return new SubmitActionPart(_Fi);
            }
        }

        public class SubmitActionPart
        {
            private FormInfo _Fi;

            public SubmitActionPart(FormInfo fi)
            {
                _Fi = fi;
            }

            public SubmitControllerPart Controller(string controller)
            {
                _Fi.SubmitController = controller;
                return new SubmitControllerPart(_Fi);
            }
        }

        public class SubmitControllerPart
        {
            private FormInfo _Fi;

            public SubmitControllerPart(FormInfo fi)
            {
                _Fi = fi;
            }

            public void Area(string area)
            {
                _Fi.SubmitArea = area;
            }
        }
    }
}
