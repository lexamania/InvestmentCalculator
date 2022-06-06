using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentCalculator.Lib.Common
{
    public class ExecutionResult<T>
    {
		public ExecutionSuccess State { get; set; }
		public T Result { get; set; }

		public ExecutionResult(string message = null)
		{
			State = new ExecutionSuccess(message);
		}
    }

	public class ExecutionSuccess
	{
		public string Message { get; private set; }
		public bool Success { get; private set; }

		public ExecutionSuccess(string message = null)
		{
			Success = string.IsNullOrEmpty(message);
			Message = message;
		}
	}
}