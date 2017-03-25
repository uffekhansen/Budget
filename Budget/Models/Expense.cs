namespace Budget.Models
{
	public class Expense
	{
		public Expense(string name, decimal amount)
		{
			Name = name;
			Amount = amount;
		}

		public string Name { get; set; }

		public decimal Amount { get; private set; }
	}
}
