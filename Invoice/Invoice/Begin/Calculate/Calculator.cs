using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Begin.People;
using Invoice.Begin.Union;

namespace Invoice.Begin.Calculate
{
    public class Calculator: IInvoiceCalculator
    {
        //Kompanija yra PVM mokėtoja
        public double Calculate(Customer customer, Provider provider, Order order) {

            double sum;
            int VAT = 0;
           IIsEuropeanUnion isEu = new IsEuropean();
            bool isCustomerEU = isEu.IsEurope(customer.GetCountry().GetName());
            bool isProviderEU = isEu.IsEurope(provider.GetCountry().GetName());

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
                            VAT = customer.GetCountry().GetVAT();
                        }
                    }
                    else {
                        if (customer.GetCountry().GetName()== provider.GetCountry().GetName())
                        {
                            VAT = 0;
                        }
                    }
                }
                if (customer.GetCountry().GetName() == provider.GetCountry().GetName())
                {
                    VAT = customer.GetCountry().GetVAT();
                }
            }

            sum = order.GetPrice() + order.GetPrice() / 100 * VAT;
            return 0;

        }

    }
}
