using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Reflection.Context;
using Bank.Reflection.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Reflection.Data
{
    internal class Queries
    {
        private readonly BankContext _context;

        public Queries(BankContext context)
        {
            _context = context;
        }

        // Tüm ödeme yöntemlerini getirme
        public async Task<ICollection<PaymentMethod>> GetAllPaymentMethodAsync()
        {
			ICollection<PaymentMethod> paymentMethods = await _context.PaymentMethods.ToListAsync();

            return paymentMethods;


		}

		// Tüm ödeme işlemlerini getirme
		public async Task<ICollection<PaymentTransaction>> GetAllPaymentTransactionAsync()
        {
			ICollection<PaymentTransaction> paymentTransaction = await _context.PaymentTransactions.Include(pt => pt.PaymentMethod).ToListAsync();

			return paymentTransaction;

		}
    }
}
