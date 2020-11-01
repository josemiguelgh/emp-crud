using System;
using System.Linq.Expressions;

namespace UPS.EmployeeMaintenance.WPFClient.ViewModel
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyNameString<TOwner, TProperty>(
            this Expression<Func<TOwner, TProperty>> propertyGetter)
        {
            var expression =
                propertyGetter.Body as MemberExpression
                ?? (MemberExpression)((UnaryExpression)propertyGetter.Body).Operand;
            return expression.Member.Name;
        }

    }
}