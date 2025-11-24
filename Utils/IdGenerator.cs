namespace QLCHgiay.Utils
{
	public static class IdGenerator
	{
		public static string GenerateNextId(string? lastId, string prefix)
		{
			if (string.IsNullOrEmpty(lastId))
			{
				return $"{prefix}001";
			}

			var numberPartString = lastId.Replace(prefix, "");

			int currentNumber;

			if (int.TryParse(numberPartString, out currentNumber))
			{
				int nextNumber = currentNumber + 1;
				string nextNumberString = nextNumber.ToString("D3");
				return $"{prefix}{nextNumberString}";
			}
			else
			{
				return $"{prefix}001";
			}
		}
	}
}
