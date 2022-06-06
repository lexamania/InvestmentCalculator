using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentCalculator.Lib.Models
{
	public class InvestmentModel
	{
		public InvestmentModel(DateTime agreementDate, DateTime calculationDate, decimal investmentSum, float investmentRate, int investmentDurationInYears)
		{
			this.AgreementDate = agreementDate;
			this.InvestmentSum = investmentSum;
			this.InvestmentDurationInYears = investmentDurationInYears;
			this.CalculationDate = calculationDate;
			this.InvestmentRate = investmentRate;
		}

		public DateTime AgreementDate { get; set; }
		public DateTime CalculationDate { get; set; }
		public decimal InvestmentSum { get; set; }
		public float InvestmentRate { get; set; }
		public int InvestmentDurationInYears { get; set; }

	}
}