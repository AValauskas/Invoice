using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Begin.People;
using Invoice.Begin.Calculate;
using Invoice.Begin.Union;



namespace Invoice.Begin.Invoice
{
    public class Invoicee:IInvoice
    {
        public double Calculate()
        {
            Customer customer = new Customer(new Country("LT", 21), new Company("Kompanija"));
            Provider provider = new Provider(new Country("LT", 21), new Company("ProviderCompany"));
            Order order = new Order(15);
            IInvoiceCalculator invoiceCalulate = new InvoiceCalculator();
            invoiceCalulate.CountryProvider = new CountryInfoProvider();
            var some = invoiceCalulate.Calculate(customer,provider,order);

            return some;
        }
    }
}
