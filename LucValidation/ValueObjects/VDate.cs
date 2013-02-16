using System;

namespace LucValidation
{
	public class VDateTime : VObject
	{
		public DateTime Value { get; set; }

		public VDateTime(DateTime val)
		{
			Value = val;
		}

		public static implicit operator VDateTime(DateTime val)
		{
			return new VDateTime(val);
		}

		public static implicit operator VDateTime(string val)
		{
            if (val == null)
                return null;
            DateTime result;
            if (DateTime.TryParse(val, out result))
            {
                return new VDateTime(result) { IsValid = true };
            }
            return new VDateTime(DateTime.MinValue) { IsValid = false };
        }

		public static implicit operator DateTime(VDateTime val)
		{
			return val.Value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}

		public override bool Equals(object obj)
		{
			VDateTime s = obj as VDateTime;
			if (s == null)
				return false;
			return
				s.Value.Equals(this.Value);
		}

		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

        public override string ErrorMessage
        {
            get { return ValidationMessagesProvider.Current.InvalidFormatDateTime; }
        }

	}
}