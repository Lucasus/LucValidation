using System;
using System.Text.RegularExpressions;

namespace LucValidation
{
	/// <summary>
	/// Klasa ta zawiera różne możliwości walidacji wartości przy pomocy klasy Validation
	/// </summary>
	public static class ValidationExtensions
	{
		private static SingleValidationResult isTrue(bool expression)
		{
			return expression == true ? (SingleValidationResult)new SingleValidationOK() : new SingleValidationError();
		}

        public static SingleValidationResult ShouldBeNull<T>(this T item)
        {
            return isTrue(item == null);
        }

		public static SingleValidationResult ShouldBeNotNull<T>(this T item) 
		{
			return isTrue(item != null);
		}

		public static SingleValidationResult ShouldBeNotNullAndNotEmpty(this string item)
		{
			return isTrue(String.IsNullOrEmpty(item) == false);
		}

		public static SingleValidationResult ShouldMatchUserNamePattern(this string item)
		{
			return isTrue(new Regex(@"^[a-zA-Z][a-zA-Z0-9._\-]*$").IsMatch(item));
		}

        public static bool IsValidUserName(this string item)
        {
            return new Regex(@"^[a-zA-Z][a-zA-Z0-9._\-]*$").IsMatch(item);
        }

		public static bool IsValidGuid(this string item)
		{
			return new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$").IsMatch(item);
		}

        public static bool IsValidEmail(this string item)
        {
            return new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").IsMatch(item);
        }

		public static SingleValidationResult ShouldMatchEmailPattern(this string item)
		{
			return isTrue(new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").IsMatch(item));
		}

		public static SingleValidationResult ShouldNoLongerThan(this string item, int limit)
		{
			return isTrue(item == null || item.Length <= limit);
		}

        public static SingleValidationResult ShouldNoShorterThan(this string item, int limit)
        {
            return isTrue(item != null && item.Length >= limit);
        }

		public static SingleValidationResult ShouldBePositive(this int item)
		{
			return isTrue(item > 0);
		}

		public static SingleValidationResult ShouldBeTrue(this bool item)
		{
			return isTrue(item == true);
		}

		public static SingleValidationResult ShouldBeFalse(this bool item)
		{
			return isTrue(item == false);
		}

		public static SingleValidationResult ShouldBeSameAs<T>(this T item, T valueToCompare)
		{
			return isTrue(item == null && valueToCompare == null || item != null && item.Equals(valueToCompare));
		}

        public static bool IsSameAs<T>(this T item, T valueToCompare)
        {
            return item == null && valueToCompare == null || item != null && item.Equals(valueToCompare);
        }

	}
}
