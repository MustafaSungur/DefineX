
using System;
using Bank.Reflection.Services.Abstract;

namespace Bank.Reflection.Services.Concrete
{
    public class Bitcoin : IPayment
    {
        public string ProcessPayment(double amount) => 
           $"The payment of {amount} TL was successfully processed with Bitcoin .";
    }
}