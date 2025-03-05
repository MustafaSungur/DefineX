using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Reflection.Entities
{
	public class PaymentMethod
	{
		public Guid Id { get; set; }

		public string Value { get; set; }

		public string DisplayName { get; set; }

		public ICollection<PaymentTransaction> Transactions { get; set; } = new List<PaymentTransaction>();
	}

}
