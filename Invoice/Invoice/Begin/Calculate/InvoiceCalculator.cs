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
            int VAT = 0, VATProvider, VATCustomer;         
           

            if (CountryProvider==null)
            {
                throw new BussinessException("Not Specified CountryProvider");
            }
            if (VATGetter == null)
            {
                throw new BussinessException("Not Specified VATGetter");
            }

            isCustomerEU = CountryProvider.IsInEurope(customer.GetCountry());
            isProviderEU = CountryProvider.IsInEurope(provider.GetCountry());
            VATCustomer = VATGetter.GetVAT(customer.GetCountry());     
            VATProvider = VATGetter.GetVAT(provider.GetCountry());

            if (VATCustomer==0)
            {
                throw new BussinessException("Customer VAT were not found, edit your Country VAT list");
            }
            if (VATProvider == 0)
            {
                throw new BussinessException("Provider VAT were not found, edit your Country VAT list");
            }

            // 1 variantas
            /*  if (provider.GetCompany() == null || provider.GetCompany().GetIFVAT() == false) 
              {
               VAT = 0;
                }
           else {
               if (isCustomerEU == false)
               {
                   VAT = 0;
               }
               else {

                   if (customer.GetCompany() == null || customer.GetCompany().GetIFVAT() == false)
                   {
                       if (customer.GetCountry().GetName() != provider.GetCountry().GetName())
                       {
                              VAT = VATProvider;
                       }
                   }
                   else {
                       if (customer.GetCountry().GetName() == provider.GetCountry().GetName())
                       {
                           VAT = 0;
                       }
                   }
               }            
           }
              if (customer.GetCountry().GetName() == provider.GetCountry().GetName())
              {
                  VAT = VATCustomer;
              }*/


            //2 variantas
            if ((customer.GetCountry().GetName() == provider.GetCountry().GetName()))
            {
                VAT = VATCustomer;
            }
            if (provider.GetCompany().GetIFVAT()==true && isCustomerEU == true && (customer.GetCompany() == null || customer.GetCompany().GetIFVAT() == false) && customer.GetCountry().GetName() != provider.GetCountry().GetName())
            {                
                    VAT = VATProvider;                
            }
            sum = order.GetPrice() + order.GetPrice() / 100 * VAT;
         return sum;         
        }

    }
}
