using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace G2RF.Extensions.Linq.Expressions
{
    public static class LinqExpressionsExtensions
    {
        public static PropertyInfo GetPropertyInfo<T, R>(this Expression<Func<T,R>> expresion)
        {
            Type type = typeof(T);

            MemberExpression member;

            // if the return value had to be cast to object, the body will be an UnaryExpression
            var unary = expresion.Body as UnaryExpression;
            if (unary != null)
            {
                // the operand is the "real" property access
                member = unary.Operand as MemberExpression;
            }
            else
            {
                // in case the property is of type object the body itself is the correct expression
                member = expresion.Body as MemberExpression;
            }

            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    expresion.ToString()));

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    expresion.ToString()));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    expresion.ToString(),
                    type));

            return propInfo;
        }
    }
}
