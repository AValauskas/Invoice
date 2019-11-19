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
            bool isCustomerEU = false;
            double sum;
            int VAT = 0, VATProvider, VATCustomer;
            try
            {
                 isCustomerEU = CountryProvider.IsEurope(customer);
                bool isProviderEU = CountryProvider.IsEurope(provider);
                VATProvider = VATGetter.GetVAT(provider);
                VATCustomer = VATGetter.GetVAT(customer);

            }
            catch (System.NullReferenceException ex)
            {
                throw new System.ArgumentNullException(
           "Parameter index is out of range.", ex);
            }
            finally {
                sum = 0;
                
            }


           

            if (provider.GetCompany() == null)  //Nežinau ar tikslinga, nes Įmonė visada moka PVM mokesčius
            {
             VAT = 0;
              }
         else {
             if (isCustomerEU == false)
             {
                 VAT = 0;
             }
             else {

                 if (customer.GetCompany() == null && customer.GetIfIndividualAction() == false)
                 {
                     if (customer.GetCountry().GetName() != provider.GetCountry().GetName())
                     {
                            VAT = VATCustomer;
                     }
                 }
                 else {
                     if (customer.GetCountry().GetName() == provider.GetCountry().GetName())
                     {
                         VAT = 0;
                     }
                 }
             }
             if (customer.GetCountry().GetName() == provider.GetCountry().GetName())
             {
                    VAT = VATCustomer;
             }
         }
         sum = order.GetPrice() + order.GetPrice() / 100 * VAT;
         return sum;
         
        }

    }
}
