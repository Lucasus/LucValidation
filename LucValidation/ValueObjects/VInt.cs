namespace LucValidation
{
	public class VInt : VObject
	{
		public int Value { get; set; }

		public VInt(int val)
		{
			Value = val;
		}

		public static implicit operator VInt(int s)
		{
            return new VInt(s) { IsValid = true };
		}

		public static implicit operator VInt(string s)
		{
            if (s == null)
                return null;
            int result;
            if (int.TryParse(s, out result))
            {
                return new VInt(result) { IsValid = true };
            }
            return new VInt(0) { IsValid = false };
        }

		public static implicit operator int(VInt s)
		{
			return s.Value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}

		public override bool Equals(object obj)
		{
			VInt s = obj as VInt;
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
            get { return ValidationMessagesProvider.Current.InvalidFormatInt; }
        }
    }
}