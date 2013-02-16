using System;

namespace LucValidation
{
	public static class StringExtensions
	{
		public static string FirstLetterToUpper(this string s)
		{ 
            if (string.IsNullOrEmpty(s))
                return s;

            return Char.ToUpper(s[0]) + s.Substring(1);
		}

		public static Guid? ToGuid(this string s)
		{
			return new Guid?(Guid.Parse(s));
		}

	}
}
