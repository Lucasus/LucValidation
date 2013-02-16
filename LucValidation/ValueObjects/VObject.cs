namespace LucValidation
{
    public abstract class VObject
    {
        public bool IsValid { get; set; }
        public abstract string ErrorMessage { get; }
    }
}
