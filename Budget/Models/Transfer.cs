namespace Budget.Models
{
	public class Transfer
	{
		public Transfer(string name, decimal amount, Account receiver)
		{
			Name = name;
			Amount = amount;
			Receiver = receiver;
		}

		public string Name { get; set; }

		public decimal Amount { get; private set; }

		public Account Receiver { get; private set; }
	}
}
