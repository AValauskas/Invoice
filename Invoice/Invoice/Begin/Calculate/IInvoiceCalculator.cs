using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Begin.People;
using Invoice.Begin.Union;

namespace Invoice.Begin.Calculate
{
    public interface IInvoiceCalculator 
    {
        public double Calculate(Customer customer, Provider provider, Order order);
    }
}
