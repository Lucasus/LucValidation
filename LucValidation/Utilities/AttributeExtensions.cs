using Castle.DynamicProxy;
using System;
using System.Linq;

namespace LucValidation
{
    public static class AttributeExtensions
    {
        public static T GetMethodAttribute<T>(this IInvocation invocation) where T : Attribute
        {
            object[] attributes = invocation.Method.GetCustomAttributes(typeof(T), true);
            if (attributes.Length > 0)
            {
                return  attributes.Single() as T;
            }
            return null;
        }
    }
}
