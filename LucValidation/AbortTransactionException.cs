using System;

namespace LucValidation
{
    public class AbortTransactionException : Exception
    {
        public ValidationResult ValidationResult { get; set; }
    }
}
