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
        public ICountryInfoProvider CountryProvider { get; set; }
        public IVatGetter VATGetter { get; set; }
        public double Calculate(Customer customer, Provider provider, Order order);
    }
}
