using Castle.DynamicProxy;
using System;
using System.Reflection;

namespace LucValidation
{
    public class ValidateArgumentsInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var service = invocation.InvocationTarget as AbstractService;            

            var validateArgumentAttribute = invocation.GetMethodAttribute<ValidateArgumentsAttribute>();

            if (validateArgumentAttribute != null)
            {
                service.ValidationResult = GetParameterValidationErrors(invocation);

                if (validateArgumentAttribute.CommonErrorMessageResourceKey != null)
                {
                    service.ValidationResult.ReplaceAllWithSingleError(ValidationMessagesProvider.Current.GetText(validateArgumentAttribute.CommonErrorMessageResourceKey));
                }
            }

            if (service.ValidationResult.IsValid || validateArgumentAttribute.ProceedWithInvalidArguments)
            {
                invocation.Proceed();
            }
            else
            {
                invocation.ReturnValue = null;
            }
        }

        private ValidationResult GetParameterValidationErrors(IInvocation invocation)
        {
            ValidationResult result = new ValidationResult();
            ParameterInfo[] parameters = invocation.Method.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                if (invocation.Arguments[i] is VObject && ((VObject)invocation.Arguments[i]).IsValid == false)
                {
                    result.AddError(parameters[i].Name.FirstLetterToUpper(), ((VObject)invocation.Arguments[i]).ErrorMessage);
                    continue;
                }

                object[] attributes = parameters[i].GetCustomAttributes(typeof(ValidateArgumentAttribute), true);
                foreach (ValidateArgumentAttribute attr in attributes)
                {
                    string validationMessage = attr.Validate(invocation.Arguments[i]);
                    if (!String.IsNullOrEmpty(validationMessage))
                    {
                        result.AddError(parameters[i].Name.FirstLetterToUpper(), validationMessage);
                    }
                }
            }
            return result;
        }

    }
}
