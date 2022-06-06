using System;

namespace InvestmentCalculator.Lib
{
	public static class Class1
	{
		public static bool StartsWithUpper(this string str)
		{
			if (string.IsNullOrWhiteSpace(str))
				return false;

			char ch = str[0];
			return char.IsUpper(ch);
		}
	}
}
