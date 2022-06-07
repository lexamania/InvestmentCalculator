using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using InvestmentCalculator.Lib.Common;
using InvestmentCalculator.Lib.Interfaces;
using InvestmentCalculator.Lib.Models;

namespace InvestmentCalculator.Desktop.Models
{
	public class CalculatorViewModel : INotifyPropertyChanged
	{
		private readonly IInvestmentCalculateService _investmentCalculator;
		public CalculatorViewModel(IInvestmentCalculateService investmentCalculator)
		{
			_investmentCalculator = investmentCalculator;
			State = new ExecutionSuccess();
		}

		private DateTime _agreementDate;
		private DateTime _calculationDate;
		private double _investmentSum;
		private float _investmentRate;
		private int _investmentDurationInYears;
		private double _result;
		private ExecutionSuccess _state;

		public DateTime AgreementDate
		{
			get => _agreementDate;
			set
			{
				_agreementDate = value;
				OnPropertyChanged();
			}
		}
		public DateTime CalculationDate
		{
			get => _calculationDate;
			set
			{
				_calculationDate = value;
				OnPropertyChanged();
			}
		}
		public double InvestmentSum
		{
			get => _investmentSum;
			set
			{
				_investmentSum = value;
				OnPropertyChanged();
			}
		}
		public float InvestmentRate
		{
			get => _investmentRate;
			set
			{
				_investmentRate = value;
				OnPropertyChanged();
			}
		}
		public int InvestmentDurationInYears
		{
			get => _investmentDurationInYears;
			set
			{
				_investmentDurationInYears = value;
				OnPropertyChanged();
			}
		}
		public double Result
		{
			get => _result;
			set
			{
				_result = value;
				OnPropertyChanged();
			}
		}
		public ExecutionSuccess State
		{
			get => _state;
			set
			{
				_state = value;
				OnPropertyChanged();
			}
		}

		public void CalculateSum()
		{
			var model = new InvestmentModel()
			{
				AgreementDate = AgreementDate, 
				CalculationDate = CalculationDate, 
				InvestmentSum = InvestmentSum, 
				InvestmentRate = InvestmentRate,
				InvestmentDurationInYears = InvestmentDurationInYears
			};
			var result = _investmentCalculator.CalculateSum(model);
			Result = result.Result;
			State = result.State;
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}