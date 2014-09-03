using System;
using System.Collections.Generic;
using System.Linq;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using FluentValidation;
using System.Linq.Expressions;
using G2RF.Web.Mvc.FluentViewModel.Mapping;
using G2RF.Web.Mvc.FluentViewModel.Form.Validation;
using G2RF.Web.Mvc.FluentViewModel.Common;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    public class FormPropertyValidatablePart<TModel, TProperty> : FormPropertyBasePart<TModel, TProperty>
    {
        public FormPropertyValidatablePart(SimpleKeyValue<string, SimpleFormPropertyInfo> propertyNode, ViewModelMap<TModel> map, Expression<Func<TModel, TProperty>> propertyExpression)
            : base(propertyNode, map, propertyExpression)
        {
        }

        public void ValidateRule(Action<IRuleBuilder<TModel,TProperty>> validationRule)
        {
            var rulebuilder = _Map.RuleFor(_PropertyExpression);
            validationRule(rulebuilder);
        }

        public void ValidateRule(Action<IRuleBuilder<TModel, TProperty>> validationRule, ValidatorPositionEnum validatorPos)
        {
            _PropertyNode.Value.ValidatorPosition = validatorPos;
            var rulebuilder = _Map.RuleFor(_PropertyExpression);
            validationRule(rulebuilder);
        }
    }
}
