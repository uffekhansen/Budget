namespace Budget.Models
{
	public class Account
	{
		public Account(string name, Balance balance)
		{
			Name = name;
			Balance = balance;
		}

		public string Name { get; private set; }

		public Balance Balance { get; private set; }
	}
}
