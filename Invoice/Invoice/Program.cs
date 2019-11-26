using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Invoice.Begin.Calculate;
using Invoice.Begin.People;
using Invoice.Begin.Union;

namespace Invoice
{
    public class Program
    {
        public static void Main(string[] args)
        {
           //  CreateHostBuilder(args).Build().Run();
         //var  invoice = new IInvoiceCalculator();
            Customer customer = new Customer(new Country("JAV"), new Company("Kompanija", true));
            Provider provider = new Provider(new Country("LT"), new Company("ProviderCompany", true));
            Order order = new Order(15);
            IInvoiceCalculator invoiceCalulate = new InvoiceCalculator();
            invoiceCalulate.CountryProvider = new CountryInfoProvider();
            invoiceCalulate.VATGetter = new VATGetter();
            invoiceCalulate.Calculate(customer, provider, order);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
