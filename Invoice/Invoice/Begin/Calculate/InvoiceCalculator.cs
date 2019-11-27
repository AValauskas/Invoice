using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Begin.People;
using Invoice.Begin.Union;

namespace Invoice.Begin.Calculate
{
    public class InvoiceCalculator : IInvoiceCalculator
    {
        public ICountryInfoProvider CountryProvider { get; set; }

        public IVatGetter VATGetter { get; set; }
        public double Calculate(Customer customer, Provider provider, Order order)
        {            
           

            if (!provider.Company.IsVAT)
            {
                return order.Price;
            }

            if (CountryProvider==null)
            {
                throw new BussinessException("Not Specified CountryProvider");
            }
            if (VATGetter == null)
            {
                throw new BussinessException("Not Specified VATGetter");
            }
           
            var isCustomerEU = CountryProvider.IsInEurope(customer.Country);
            var isProviderEU = CountryProvider.IsInEurope(provider.Country);
            var customerVAT = VATGetter.GetVAT(customer.Country);
            var providerVAT = VATGetter.GetVAT(provider.Country);
            int? applicableVAT = null;

            if (customer.Country == provider.Country)
            {
                applicableVAT = customerVAT;
            }
            else
            {
                if (isCustomerEU 
                    && (customer.Company == null || customer.Company.IsVAT == false) 
                    && customer.Country != provider.Country)
                {
                    applicableVAT = providerVAT;
                }
            }
            if (applicableVAT != null)
            {
                return order.Price + order.Price / 100 * applicableVAT.Value;
            }
            return order.Price;
        }

    }
}
