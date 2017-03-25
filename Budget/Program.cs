using System;
using Budget.Models;

namespace Budget
{
	class Program
	{
		static void Main(string[] args)
		{
			var savings = new Account("Opsparing", new Balance(5000));
			var account = new Account("Lønkonto", new Balance(12330.34m));

			var budget = new Models.Budget(account);
			budget.Add(new Expense("Årskort", 100));
			budget.Add(new Expense("Strøm", 788));
			budget.Add(new Transfer("Opsparing", 100, savings));

			Console.WriteLine("Remaining balance: {0}", budget.RemainingBalance());

			budget.NewMonth();

			Console.WriteLine("Remaining balance: {0}", budget.RemainingBalance());

			Console.ReadKey(); 
		}
	}
}
