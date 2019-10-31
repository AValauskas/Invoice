using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceApp2.Model
{
   public interface IInvoice
    {
        double VATcalculatorIndividual(Individual client, Provider provider, double price);
        double VATcalculatorCompany(Company company, Provider provider, double price);
    }
}
