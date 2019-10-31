using System;
using Xunit;
using Invoice.Controllers;
using Invoice.Models;
using Invoice;
using NSubstitute;


namespace InvoiceTests
{
    public class InvoiceVatPriceTestsMocking
    {

        [Fact]
        public void ProviderControler_WriteInvoiceCompany_Provider_Not_VAT_Payer_Return0()
        {
            var Provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", false);

            var client = new Company("356566", "company", "uab Rab", "Spain", 30, "37", true, true);

            double price = 100;
            var providertasks = Substitute.For<Provider>();
            var companytasks = Substitute.For<Company>();

            providertasks.Login().Returns(Provider);
            providertasks.getPrice().Returns(100);
            companytasks.GetCompany().Returns(client);
            InvoiceW invoice = new InvoiceW();
            Assert.Equal(0, invoice.VATcalculatorCompany(client, Provider, price), 0);


        }
/*

        [Fact]
        public void Provider_is_VAT_Payer_Client_NOT_EU_Return_0()
        {
            var Provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Individual("356566", "individual", "JA klientas", "Spain", 30, "Paðilës 37", false, true);

            double price = 100;
            //  var invoice = new Invoice();

            //     var result = invoice.VATcalculator(client, Provider, price);

            var calculator = Substitute.For<IInvoice>();

            Assert.Equal(0, calculator.VATcalculatorIndividual(client, Provider, price), 0);
        }


        [Fact]
        public void Provider_is_VAT_Payer_Client_Lives_EU_NOT_VAT_Payer_Diffirent_Country_Return_30()
        {
            var Provider = new Provider("UAB tiekëjas", "Spain", 21, "Kaunas", "326461131313", false);

            var client = new Individual("356566", "individual", "JA klientas", "Spain", 30, "Paðilës 37", true, false);

            double price = 100;
            //  var invoice = new Invoice();

            //     var result = invoice.VATcalculator(client, Provider, price);

            var calculator = Substitute.For<IInvoice>();

         //   calculator.VATcalculator(client, Provider, price).Returns(30);
            //   Assert.AreEqual(3, calculator.Add(1, 2));

          //  Assert.Equal(30, calculator.VATcalculator(client, Provider, price), 0);


            calculator.VATcalculatorIndividual(client, Provider, price);
            calculator.Received().VATcalculatorIndividual(client, Provider, 130);
             calculator.DidNotReceive().VATcalculatorIndividual(client, Provider, 120);
            // calculator += Raise.Event();
        }*/
    }
}
