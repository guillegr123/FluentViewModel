using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using G2RF.Extensions.Linq.Expressions;
using G2RF.Web.Mvc.FluentViewModel.Form.Info;
using G2RF.Web.Mvc.FluentViewModel.Common;
using System.Web.Mvc;
using System.Collections;

namespace G2RF.Web.Mvc.FluentViewModel.Form.Parts
{
    public class SimpleListEditorPart<TProperty> : EditorBasePart
    {
        protected readonly ListFormPropertyInfo _FormPropertyInfo;

        public SimpleListEditorPart(SimpleKeyValue<string, SimpleFormPropertyInfo> propertyNode) : base(propertyNode)
        {
            _PropertyNode.Value = _FormPropertyInfo
                = new ListFormPropertyInfo(propertyNode.Value);
        }

        public SimpleListEditorPart<TProperty> UsingEditorTemplate(string templateName)
        {
            _FormPropertyInfo.TemplateName = templateName;
            return this;
        }

        public SimpleListEditorPart<TProperty> AddDependentField<TModel>(Expression<Func<TModel, object>> propertyExpression)
        {
            _FormPropertyInfo.DependentFields.Add(propertyExpression.GetPropertyInfo().Name);
            return this;
        }

        public SimpleListEditorPart<TProperty> UsingAsValueField<TListModelProperty>(Expression<Func<TProperty, TListModelProperty>> memberExpression)
        {
            string memberExprStr = memberExpression.ToString();
            _FormPropertyInfo.ValueField = memberExprStr.Substring(memberExprStr.IndexOf('.') + 1); ;
            return this;
        }

        public SimpleListEditorPart<TProperty> UsingAsDisplayField<TListModelProperty>(Expression<Func<TProperty, TListModelProperty>> memberExpression)
        {
            string memberExprStr = memberExpression.ToString();
            _FormPropertyInfo.DisplayField = memberExprStr.Substring(memberExprStr.IndexOf('.') + 1); ;
            return this;
        }

        public SimpleListEditorPart<TProperty> UsingTextFormat(string formato)
        {
            _FormPropertyInfo.TextFormat = formato;
            return this;
        }

        public SimpleListEditorPart<TProperty> UsingStaticOptions(IEnumerable opcionesFijas)
        {
            _FormPropertyInfo.StaticOptions = opcionesFijas;
            return this;
        }

        public SimpleListEditorPart<TProperty> UsingGetOptionsMethod(Func<IEnumerable> metodoObtenerOpciones)
        {
            _FormPropertyInfo.GetOptions = (vd) => { return metodoObtenerOpciones(); };
            return this;
        }

        public SimpleListEditorPart<TProperty> UsingGetOptionsMethod(Func<ViewDataDictionary, IEnumerable> metodoObtenerOpciones)
        {
            _FormPropertyInfo.GetOptions = metodoObtenerOpciones;
            return this;
        }
    }
}
