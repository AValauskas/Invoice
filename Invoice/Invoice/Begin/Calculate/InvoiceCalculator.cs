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
            bool isCustomerEU, isProviderEU;
            double sum;
            int VAT = 999, VATProvider, VATCustomer;         
           

            if (CountryProvider==null)
            {
                throw new BussinessException("Not Specified CountryProvider");
            }
            if (VATGetter == null)
            {
                throw new BussinessException("Not Specified VATGetter");
            }

            isCustomerEU = CountryProvider.IsInEurope(customer.Country);
            isProviderEU = CountryProvider.IsInEurope(provider.Country);
            VATCustomer = VATGetter.GetVAT(customer.Country);     
            VATProvider = VATGetter.GetVAT(provider.Country);     

            if ((customer.Country == provider.Country))
            {
                VAT = VATCustomer;
            }
            else
            {
                if (provider.Company.GetIFVAT() 
                    && isCustomerEU 
                    && (customer.Company == null || customer.Company.GetIFVAT() == false) 
                    && customer.Country.Name != provider.Country.Name)
                {
                    VAT = VATProvider;
                }
                else {
                    VAT = 0;
                }
            }
            sum = order.Price + order.Price / 100 * VAT;
         return sum;         
        }

    }
}
