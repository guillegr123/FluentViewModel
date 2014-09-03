using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using G2RF.Web.Mvc.FluentViewModel.Common;
using G2RF.Web.Mvc.FluentViewModel.Mapping;
using System.Linq.Expressions;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    public class FormPropertyPart<TModel, TProperty> : FormPropertyEditablePart<TModel, TProperty>
    {
        public FormPropertyPart(SimpleKeyValue<string, SimpleFormPropertyInfo> propertyNode, ViewModelMap<TModel> map, Expression<Func<TModel, TProperty>> propertyExpression)
            : base(propertyNode, map, propertyExpression)
        {
        }

        public FormPropertyPart<TModel, TProperty> WithLabel(string label)
        {
            _PropertyNode.Value.Label = label;
            return this;
        }

        public FormPropertyEditablePart<TModel, TProperty> Display()
        {
            return new FormPropertyEditablePart<TModel, TProperty>(_PropertyNode, _Map, _PropertyExpression);
        }

        //public SimpleFormPropertyPart<T> AsTextBox()
        //{
        //    _PropertyNode.Value.EditorType = HtmlEditorType.TextoSimple;
        //    return new SimpleFormPropertyPart<T>(_PropertyNode);
        //}

        //public SimpleFormPropertyPart<T> AsPassword()
        //{
        //    _PropertyNode.Value.EditorType = HtmlEditorType.Contrasena;
        //    return new SimpleFormPropertyPart<T>(_PropertyNode);
        //}

        //public SimpleFormPropertyPart<T> AsCheckBox()
        //{
        //    _PropertyNode.Value.EditorType = HtmlEditorType.Booleano;
        //    return new SimpleFormPropertyPart<T>(_PropertyNode);
        //}

        //public void AsHidden()
        //{
        //    _PropertyNode.Value.EditorType = HtmlEditorType.Oculto;
        //    //return new PropiedadFormSimplePart<T>(propertyNode);
        //}
    }
}
