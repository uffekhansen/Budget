using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Models
{
	public class Budget
	{
		public Budget(Account account)
		{
			Account = account;

			MonthlyExpenses = new List<Expense>();
			MonthlyTransfers = new List<Transfer>();
			ReservedForExpenses = new Dictionary<string, decimal>();
		}

		public IList<Expense> MonthlyExpenses { get; private set; }

		public IList<Transfer> MonthlyTransfers { get; private set; }

		private IDictionary<string, decimal> ReservedForExpenses { get; set; }

		public Account Account { get; private set; }

		private void Validate(Expense expense)
		{
			if(MonthlyExpenses.Any(e => e.Name.ToLower() == expense.Name.ToLower()))
			{
				throw new ArgumentException("Can't add expense {0} because an expanse with a matching name exists", expense.Name);
			}
		}

		public decimal RemainingBalance()
		{
			return Account.Balance.Amount - ReservedForExpenses.Sum(pair => pair.Value);
		}

		public decimal GetBalance()
		{
			return Account.Balance.Amount;
		}

		public void Add(Expense expense)
		{
			Validate(expense);

			ReservedForExpenses[expense.Name] = 0;
			MonthlyExpenses.Add(expense);
		}

		public void Add(Transfer transfer)
		{
			MonthlyTransfers.Add(transfer);
		}
		
		public decimal MonthlyTotal()
		{
			return MonthlyExpenses.Sum(expense => expense.Amount)
				+ MonthlyTransfers.Sum(transfer => transfer.Amount);
		}

		public void NewMonth()
		{
			foreach (var expense in MonthlyExpenses)
			{
				ReservedForExpenses[expense.Name] += expense.Amount;
			}
		}
	}
}
