using System;
using System.Collections.Generic;
using System.Linq;

namespace LucValidation
{
	/// <summary>
	/// Klasa ta ma za zadanie służyć jako argument zwracany przez różne funkcje, które walidują swoje argumenty i chcą zwrócić wynik tej walidacji
	/// </summary>
	public class ValidationResult
	{
        public static ValidationResult IsOK { get; private set; }

        static ValidationResult()
        {
            IsOK = new ValidationResult();
        }

        public ValidationResult()
        {
            Errors = new Dictionary<string, IList<string>>();
            GeneralErrors = new List<string>();
        }

		public IDictionary<string, IList<string>> Errors { get; protected set; }
		public IList<string> GeneralErrors { get; protected set; }
		
		public bool IsValid
		{
			get { return Errors.Count == 0 && GeneralErrors.Count == 0; }
		}

		public int ErrorCount
		{
			get 
            {
                return GeneralErrors.Count + (from key in Errors.Keys select Errors[key].Count).Sum();
            }
		}

		public void AddError(string key, string message)
		{
			if (key.Equals(String.Empty))
			{
                if (!GeneralErrors.Contains(message))
                {
                    GeneralErrors.Add(message);
                }
			}
			else
			{
				if (!Errors.ContainsKey(key))
				{
					Errors.Add(key, new List<string>());
				}
                if (!Errors[key].Contains(message))
                {
                    Errors[key].Add(message);
                }
			}
        }

        public void AddError(string message)
        {
            AddError(String.Empty, message);
        }


		public ValidationResult ReplaceAllWithSingleError(string key, string message)
		{
			if (ErrorCount > 0)
			{
				Errors.Clear();
				GeneralErrors.Clear();
				AddError(key, message);
			}
			return this;
		}

		public ValidationResult ReplaceAllWithSingleError(string message)
		{
			return ReplaceAllWithSingleError(String.Empty, message);
		}

        public void CopyErrorsFrom(ValidationResult result)
        {
            Errors.Clear();
            GeneralErrors.Clear();

            foreach (string key in result.Errors.Keys)
            {
                foreach (string message in result.Errors[key])
                {
                    AddError(key, message);
                }
            }

            foreach (string message in result.GeneralErrors)
            {
                AddError(message);
            }

        }
	}
}
