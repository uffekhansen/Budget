namespace Budget.Models
{
	public class Balance
	{
		public Balance(decimal amount)
		{
			Amount = amount;
		}

		public decimal Amount { get; private set; }
	}
}
