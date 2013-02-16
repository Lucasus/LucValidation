using System;

namespace LucValidation
{
	[AttributeUsage(AttributeTargets.All, Inherited=true, AllowMultiple=true )]
	public abstract class ValidateArgumentAttribute : Attribute
	{
		public abstract string Validate(object value);
        public string OK { get { return null; } }
	}
}
