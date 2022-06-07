using InvestmentCalculator.Lib.Interfaces;
using InvestmentCalculator.Lib.Models;
using InvestmentCalculator.Lib.Services;

namespace InvestmentCalculator.Tests
{
	[TestClass]
	public class InvestmentModuleTest
	{
		private readonly IInvestmentCalculateService _investmentCalculateService;

		public InvestmentModuleTest()
		{
			_investmentCalculateService = new InvestmentCalculateService();
		}

		[TestMethod]
		public void InvestmentPayment_AfterOneYear_WithOneYear_By10Rate()
		{
			var agreeDate = new DateTime(0001, 1, 1);
			var calcDate = agreeDate.AddYears(1);

			var model = new InvestmentModel()
			{
				AgreementDate = agreeDate,
				CalculationDate = calcDate,
				InvestmentDurationInYears = 1,
				InvestmentRate = 10,
				InvestmentSum = 100000
			};

			double expected = 110000;
			double result = _investmentCalculateService.CalculateSum(model).Result;

			Assert.AreEqual(expected, result, "Investment sum 1 year from 1 is not correct.");
		}

		[TestMethod]
		public void InvestmentPayment_AfterOneYear_WithTenYear_By10Rate()
		{
			var agreeDate = new DateTime(0001, 1, 1);
			var calcDate = agreeDate.AddYears(1);

			var model = new InvestmentModel()
			{
				AgreementDate = agreeDate,
				CalculationDate = calcDate,
				InvestmentDurationInYears = 10,
				InvestmentRate = 10,
				InvestmentSum = 100000
			};

			double expected = 20000;
			double result = _investmentCalculateService.CalculateSum(model).Result;

			Assert.AreEqual(expected, result, "Investment sum 1 year from 10 is not correct.");
		}

		[TestMethod]
		public void InvestmentPayment_AfterOneYearAndOneNotFullMonth_WithTenYear_By10Rate()
		{
			var agreeDate = new DateTime(0001, 1, 1);
			var calcDate = agreeDate.AddYears(1).AddDays(20);

			var model = new InvestmentModel()
			{
				AgreementDate = agreeDate,
				CalculationDate = calcDate,
				InvestmentDurationInYears = 10,
				InvestmentRate = 10,
				InvestmentSum = 100000
			};

			double expected = 20000;
			double result = _investmentCalculateService.CalculateSum(model).Result;

			Assert.AreEqual(expected, result, "Investment sum 1 year and 1 half month from 10 years is not correct.");
		}

		[TestMethod]
		public void InvestmentPayment_AfterOneFullMonth_WithTenYear_By10Rate()
		{
			var agreeDate = new DateTime(0001, 1, 1);
			var calcDate = agreeDate.AddMonths(1).AddDays(1);

			var model = new InvestmentModel()
			{
				AgreementDate = agreeDate,
				CalculationDate = calcDate,
				InvestmentDurationInYears = 10,
				InvestmentRate = 10,
				InvestmentSum = 100000
			};

			double expected = 1666.666;
			double result = _investmentCalculateService.CalculateSum(model).Result;

			Assert.AreEqual(expected, result, 0.001, "Investment sum 1 full month from 10 years is not correct.");
		}

		[TestMethod]
		public void InvestmentPayment_UnvalidField_CalculationDate_More()
		{
			var agreeDate = new DateTime(0010, 1, 1);
			var calcDate = agreeDate.AddYears(4).AddDays(1);

			var model = new InvestmentModel()
			{
				AgreementDate = agreeDate,
				CalculationDate = calcDate,
				InvestmentDurationInYears = 4,
				InvestmentRate = 10,
				InvestmentSum = 100000
			};

			bool expected = false;
			bool result = _investmentCalculateService.CalculateSum(model).State.Success;

			Assert.AreEqual(expected, result, "Validation 'more' for CalculationDate is not correct.");
		}

		[TestMethod]
		public void InvestmentPayment_UnvalidField_CalculationDate_Less()
		{
			var agreeDate = new DateTime(0010, 1, 1);
			var calcDate = agreeDate.AddDays(-1);

			var model = new InvestmentModel()
			{
				AgreementDate = agreeDate,
				CalculationDate = calcDate,
				InvestmentDurationInYears = 4,
				InvestmentRate = 10,
				InvestmentSum = 100000
			};

			bool expected = false;
			bool result = _investmentCalculateService.CalculateSum(model).State.Success;

			Assert.AreEqual(expected, result, "Validation 'less' for CalculationDate is not correct.");
		}
		
	}
}