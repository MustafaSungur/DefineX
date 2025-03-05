﻿
using System;
using Bank.Reflection.Services.Abstract;

namespace Bank.Reflection.Services.Concrete
{
    public class Paypal : IPayment
    {
        public string ProcessPayment(double amount) => 
           $"The payment of {amount} TL was successfully processed with PayPal.";
    }
}