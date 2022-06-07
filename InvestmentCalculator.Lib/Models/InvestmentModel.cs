using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentCalculator.Lib.Models
{
	public class InvestmentModel
	{
		public DateTime AgreementDate { get; set; }
		public DateTime CalculationDate { get; set; }
		public double InvestmentSum { get; set; }
		public double InvestmentRate { get; set; }
		public int InvestmentDurationInYears { get; set; }

	}
}