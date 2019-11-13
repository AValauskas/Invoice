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
            Customer customer = new Customer("customer", new Country("LT", 21), new Company("Kompanija"));
            Provider provider = new Provider("provider", new Country("LT", 21), new Company("ProviderCompany"));
            Order order = new Order(15);
            //IIsEuropeanUnion euro = new IsEuropean(); 
            IInvoiceCalculator icalculator = new Calculator();
            var some = icalculator.Calculate(customer,provider,order);

            return some;
        }
    }
}
