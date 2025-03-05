using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Reflection.Entities
{
	public class PaymentTransaction
	{
		public Guid Id { get; set; }  

		public Guid PaymentMethodId { get; set; }  

		public PaymentMethod? PaymentMethod { get; set; }

		public double Amount { get; set; }  

		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;  
	}
}
