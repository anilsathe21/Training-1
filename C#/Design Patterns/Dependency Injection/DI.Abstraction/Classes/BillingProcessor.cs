﻿using DI.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Abstraction.Classes
{
    public class BillingProcessor : IBillingProcessor
    {
        public void ProcessPayment(string customerName, int creditCard, int price)
        {
            Console.WriteLine("Processing payment of {0} for customer {1} with credit card {2}", price, customerName, creditCard);
        }
    }
}
