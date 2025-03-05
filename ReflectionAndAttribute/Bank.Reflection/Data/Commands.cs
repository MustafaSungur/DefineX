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
    public class Commands
    {
        private readonly BankContext _context;

        public Commands(BankContext context)
        {
            _context = context;
        }

        // Ödeme yöntemi ekleme
        public async Task<int> AddPaymentMethodAsync(PaymentMethod paymentMethod)
        {

            _context.PaymentMethods.Add(new PaymentMethod
            {
                Value = paymentMethod.Value,
                DisplayName = paymentMethod.DisplayName
            });

            var result = await _context.SaveChangesAsync();

            return result;
        }

        // Ödeme işlemi ekleme
        public async Task<int> AddPaymentTransactionAsync(PaymentTransaction paymentTransaction)
        {
            _context.PaymentTransactions.Add(new PaymentTransaction
            {
                Amount = paymentTransaction.Amount,
                PaymentMethodId = paymentTransaction.PaymentMethodId,
            });

            int result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
