namespace LucValidation
{
    public abstract class ValidationMessagesProvider
    {
        public static ValidationMessagesProvider Current { get; set; }

        public abstract string InvalidFormatInt { get; }
        public abstract string InvalidFormatDateTime { get; }
        public abstract string InvalidFormatBool { get; }

        public abstract string GetText(string key);
    }
}
