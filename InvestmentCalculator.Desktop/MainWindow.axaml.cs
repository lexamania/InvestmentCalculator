using Avalonia.Controls;
using InvestmentCalculator.Desktop.Models;

namespace InvestmentCalculator.Desktop
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = new CalculatorViewModel(new InvestmentCalculator.Lib.Services.InvestmentCalculator());
		}
	}
}
