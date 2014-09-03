using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using G2RF.Web.Mvc.FluentViewModel.Mapping;
using System.Linq.Expressions;
using G2RF.Web.Mvc.FluentViewModel.Common;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    //public interface IFormPropertyEditablePart<TModel, TProperty>
    //{
    //    FormPropertyValidatablePart<TModel, TProperty> Edit(Action<object> setEditor);
    //}

    public class FormPropertyEditablePart<TModel, TProperty> : FormPropertyBasePart<TModel, TProperty> //, IFormPropertyEditablePart<TModel, TProperty>
    {
        public FormPropertyEditablePart(SimpleKeyValue<string, SimpleFormPropertyInfo> propertyNode, ViewModelMap<TModel> map, Expression<Func<TModel, TProperty>> propertyExpression)
            : base(propertyNode, map, propertyExpression)
        {
        }
        
        public FormPropertyConditionalEditablePart<TModel, TProperty> Edit(Action<EditorPart<TProperty>> setEditor)
        {
            setEditor(new EditorPart<TProperty>(_PropertyNode));
            return new FormPropertyConditionalEditablePart<TModel, TProperty>(_PropertyNode, _Map, _PropertyExpression);
        }
    }
}
