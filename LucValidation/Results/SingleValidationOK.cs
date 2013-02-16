namespace LucValidation
{
	public class SingleValidationOK : SingleValidationResult
	{
		public SingleValidationOK() { }

		public override ValidationResult SaveErrorTo(ValidationResult result)
		{
			return result;
		}

		public override SingleValidationResult SetErrorMessage(string key, string message)
		{
			return this;
		}

		public override SingleValidationResult SetErrorMessage(string message)
		{
			return this;
		}

        public override bool IsValid
        {
            get { return true; }
        }

    }
}
