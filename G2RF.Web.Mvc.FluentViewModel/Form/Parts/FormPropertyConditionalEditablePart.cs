using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Mapping;
using System.Linq.Expressions;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using G2RF.Web.Mvc.FluentViewModel.Common;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    public class FormPropertyConditionalEditablePart<TModel, TProperty> : FormPropertyValidatablePart<TModel, TProperty>
    {
        public FormPropertyConditionalEditablePart(SimpleKeyValue<string, SimpleFormPropertyInfo> propertyNode, ViewModelMap<TModel> map, Expression<Func<TModel, TProperty>> propertyExpression)
            : base(propertyNode, map, propertyExpression)
        {
        }

        public FormPropertyValidatablePart<TModel, TProperty> When(Func<TModel, TProperty, bool> conditionalFunction)
        {
            //var condFuncCompiled = conditionalFunction.Compile();
            _PropertyNode.Value.CanDisplayEditor =
                (a, b) =>
                    {
                        return false;
                        //return conditionalFunction((TModel)a, (TProperty)b);
                    };
            return new FormPropertyValidatablePart<TModel, TProperty>(_PropertyNode, _Map, _PropertyExpression);
        }
    }
}
