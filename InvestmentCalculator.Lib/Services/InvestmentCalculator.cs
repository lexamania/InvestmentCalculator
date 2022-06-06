using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestmentCalculator.Lib.Common;
using InvestmentCalculator.Lib.Interfaces;
using InvestmentCalculator.Lib.Models;

namespace InvestmentCalculator.Lib.Services
{
	public class InvestmentCalculator : IInvestmentCalculator
	{
		private const int PAYMENT_FREQUENCY_IN_DAYS = 30;
		private const float YEAR_LENGTH = 365.25f;

		public ExecutionResult<decimal> CalculateSum(InvestmentModel model)
		{
			var valid = validation(model);
			if (!valid.Success) return new ExecutionResult<decimal>(valid.Message);

			decimal sumToPay = model.InvestmentSum;
			decimal sumToPayPerYear = sumToPay / model.InvestmentDurationInYears;
			var months = (model.CalculationDate.Year - model.AgreementDate.Year) * 12 + model.CalculationDate.Month - model.AgreementDate.Month - (model.CalculationDate.Day < model.AgreementDate.Day ? 1 : 0);
			var passesYears = months / 12;
			var passesMonths = months % 12;
			decimal finalSum = 0;
			
			// Sum by years
			for (int i = 0; i < passesYears; i++)
			{
				var sum = getPaymentPerYear(sumToPay, sumToPayPerYear, model.InvestmentRate);
				finalSum += sum;
				sumToPay -= sumToPayPerYear;
			}

			// Sum by months
			decimal paymentPerMonth = 0m;
			for (int i = 0; i < passesMonths; i++)
			{
				if (i % 12 == 0)
				{
					// var rateAtMonth = Math.Pow((1 + model.InvestmentRate / 100), 1f / 12f);
					paymentPerMonth = getPaymentPerYear(sumToPay, sumToPayPerYear, model.InvestmentRate) / 12;
				}
				finalSum += paymentPerMonth;
				sumToPay -= paymentPerMonth;
			}

			return new ExecutionResult<decimal>() { Result = finalSum };
		}

		private decimal getPaymentPerYear(decimal total, decimal totalPerYear, float rate)
		{
			// Without changing every month
			return totalPerYear + total * (decimal)rate / 100;
		}
		
		private ExecutionSuccess validation(InvestmentModel model)
		{
			if (model == null) return new ExecutionSuccess("No data.");
			if (model.InvestmentDurationInYears <= 0) return new ExecutionSuccess("Investment duration must be greater than 0.");
			if (model.InvestmentRate <= 0) return new ExecutionSuccess("Investment rate must be greater than 0.");
			if (model.CalculationDate <= model.AgreementDate || model.CalculationDate > model.AgreementDate.AddYears(model.InvestmentDurationInYears))
			{
				return new ExecutionSuccess($"Calculation date must be betwen {model.AgreementDate.GetDate()} and {model.AgreementDate.AddYears(model.InvestmentDurationInYears).GetDate()}.");
			}

			return new ExecutionSuccess();
		}
	}
}