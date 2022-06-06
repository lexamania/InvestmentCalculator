using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentCalculator.Lib.Common
{
	public static class Extensions
	{
		public static string GetDate(this DateTime date)
		{
			return date.ToString("dd.MM.yyyy");
		}
	}
}