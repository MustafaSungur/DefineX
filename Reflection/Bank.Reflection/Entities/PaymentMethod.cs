using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomAttribute;

namespace Bank.Reflection.Entities
{
	public class PaymentMethod
	{
		public Guid Id { get; set; }

		
		[RequiredField]
		[StringLengthRange(3, 20)]
		public string Value { get; set; }

		[RequiredField]
		[StringLengthRange(3, 20)]
		public string DisplayName { get; set; }

		public ICollection<PaymentTransaction> Transactions { get; set; } = new List<PaymentTransaction>();
	}

}
