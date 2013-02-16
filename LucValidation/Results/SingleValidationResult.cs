namespace LucValidation
{
	public abstract class SingleValidationResult
	{
		protected string key;
		protected string message;

		public abstract ValidationResult SaveErrorTo(ValidationResult result);
		public abstract SingleValidationResult SetErrorMessage(string key, string message);
		public abstract SingleValidationResult SetErrorMessage(string message);
        public abstract bool IsValid { get; }
        public virtual void Validate(string key, string message) { }
        public virtual void Validate(string message) { }
	}
}
