using System;

namespace LucValidation
{
	public class SingleValidationError : SingleValidationResult
	{
		public SingleValidationError() { }

		public override ValidationResult SaveErrorTo(ValidationResult result)
		{
			result.AddError(key, message);
			return result;
		}

		public override SingleValidationResult SetErrorMessage(string key, string message)
		{
			this.key = key;
			this.message = message;
			return this;
		}

		public override SingleValidationResult SetErrorMessage(string message)
		{
            return SetErrorMessage(String.Empty, message);
		}

		public override void Validate(string errorKey, string errorMessage)
		{
            new ValidationResult().AddError(errorKey, errorMessage);
		}

		public override void Validate(string errorMessage)
		{
			Validate(String.Empty, errorMessage);
		}

        public override bool IsValid
        {
            get { return false; }
        }
    }
}
