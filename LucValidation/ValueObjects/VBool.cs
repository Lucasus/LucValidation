using System;

namespace LucValidation
{
	public class VBool : VObject
	{
		public bool Value { get; set; }

		public VBool(bool val)
		{
			Value = val;
		}

		public static implicit operator VBool(bool val)
		{
			return new VBool(val);
		}

		public static implicit operator VBool(string val)
		{
            if (val == null)
                return null;
            bool result;
            if(Boolean.TryParse(val, out result))
            {
                return new VBool(result) { IsValid = true };
            }
            return new VBool(false) { IsValid = false };
		}

		public static implicit operator bool(VBool val)
		{
			return val.Value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}

		public override bool Equals(object obj)
		{
			VBool s = obj as VBool;
			if (s == null)
				return false;
			return
				s.Value == this.Value;
		}

		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

        public override string ErrorMessage
        {
            get { return ValidationMessagesProvider.Current.InvalidFormatBool; }
        }

	}
}