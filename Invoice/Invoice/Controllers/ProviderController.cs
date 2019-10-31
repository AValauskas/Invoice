using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Invoice.Models;

namespace Invoice.Controllers
{
    //private MydataEntities1 db = new MydataEntities1();
    public class ProviderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public double WriteInvoiceCompany(Provider provider, Company company)
        {
            Provider provideris = provider.Login();

            Company company1 = company.GetCompany();

            double price = provider.getPrice();

            InvoiceW invoice = new InvoiceW();

            double PVM = invoice.VATcalculatorCompany(company1, provideris, price);
           
            return PVM;
        }

        public double WriteInvoiceIndividual(Provider provider, Individual person)
        {
            Provider provideris = provider.Login();

            Individual individual = person.GetPerson();

            double price = provider.getPrice();

            InvoiceW invoice = new InvoiceW();

            double PVM = invoice.VATcalculatorIndividual(individual, provideris, price);

            return PVM;
        }
    }
}