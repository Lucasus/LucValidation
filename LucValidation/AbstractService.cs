namespace LucValidation
{
    public abstract class AbstractService
    {
        protected ValidationResult validationResult = new ValidationResult();
        public ValidationResult ValidationResult { get { return validationResult; } set { validationResult = value; } }

        protected bool CheckRules(params Rule[] rules)
        {
            foreach (Rule r in rules)
            {
                if (r.Check() == false)
                {
                    validationResult.AddError(r.Key, r.Message);
                    return false;
                }
            }
            return true;
        }

        protected bool CheckAllRules(params Rule[] rules)
        {
            foreach (Rule r in rules)
            {
                if (r.Check() == false)
                {
                    validationResult.AddError(r.Key, r.Message);
                }
            }
            return validationResult.IsValid;
        }

        protected ValidationResult OK()
        {
            return new ValidationResult();
        }

        public bool LastOperationSucceed
        {
            get
            {
                return validationResult.IsValid;
            }
        }
    }
}
