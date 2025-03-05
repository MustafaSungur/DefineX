using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Reflection.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Reflection.Context
{
	public class BankContext:DbContext
	{
		public DbSet<PaymentMethod> PaymentMethods { get; set; }
		public DbSet<PaymentTransaction> PaymentTransactions { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=localhost;Database=payment;Trusted_Connection=True;TrustServerCertificate=True;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// One-to-Many ilişkisi
			modelBuilder.Entity<PaymentTransaction>()
				.HasOne(t => t.PaymentMethod)
				.WithMany(p => p.Transactions)
				.HasForeignKey(t => t.PaymentMethodId)
				.OnDelete(DeleteBehavior.Restrict);  // Ödeme yöntemine bağlı ödemeler varsa ödeme yönteminin silinmesine izin vermez
		}

	}
}
