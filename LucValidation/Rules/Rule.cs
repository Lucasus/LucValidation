using System;

namespace LucValidation
{
	public abstract class Rule
	{
        public Rule()
        {
            Key = String.Empty;
        }

		public string Message { get; set; }
		public string Key { get; set; }
        public abstract bool Check();
	}
}
