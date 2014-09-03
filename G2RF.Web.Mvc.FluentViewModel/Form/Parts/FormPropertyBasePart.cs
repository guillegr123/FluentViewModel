using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using G2RF.Web.Mvc.FluentViewModel.Mapping;
using System.Linq.Expressions;
using G2RF.Web.Mvc.FluentViewModel.Common;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    public abstract class FormPropertyBasePart<TModel, TProperty>
    {
        protected internal SimpleKeyValue<string, SimpleFormPropertyInfo> _PropertyNode;
        protected internal ViewModelMap<TModel> _Map;
        protected internal Expression<Func<TModel, TProperty>> _PropertyExpression;

        public FormPropertyBasePart(SimpleKeyValue<string, SimpleFormPropertyInfo> propertyNode, ViewModelMap<TModel> map, Expression<Func<TModel, TProperty>> propertyExpression)
        {
            _PropertyNode = propertyNode;
            _Map = map;
            _PropertyExpression = propertyExpression;
        }
    }
}
