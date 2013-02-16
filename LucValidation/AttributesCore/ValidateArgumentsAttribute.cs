using System;

namespace LucValidation
{
    public class ValidateArgumentsAttribute : Attribute
    {
        private bool saveToLastArgument = false;
        private bool saveToReturnValue = false;

        public string CommonErrorMessageResourceKey { get; set; }
        public bool ProceedWithInvalidArguments { get; set; }

        public bool SaveToLastArgument
        {
            get { return saveToLastArgument; }
            set { saveToLastArgument = value; }
        }

        public bool SaveToReturnValue
        {
            get { return saveToReturnValue; }
            set { saveToReturnValue = value; }
        }

    }
}
