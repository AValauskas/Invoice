using System;
using Xunit;
using InvoiceApp2.Model;
using InvoiceApp2;
using NSubstitute;


namespace InvoiceTests
{
    public class InvoiceVatPriceTestsWithoutMocking
    {

        [Fact]
        public void Provider_Not_VAT_Payer_Return0()
        {
            var Provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", false);

            var client = new Individual("356566", "individual", "JA klientas", "Spain", 30, "Paðilës 37", true, true);

            double price = 100;

            var calculator = new InvoiceW();

            Assert.Equal(0, calculator.VATcalculatorIndividual(client, Provider, price), 0);


        }


        [Fact]
        public void Provider_is_VAT_Payer_Client_NOT_EU_Return_0()
        {
            var Provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Company("356566", "individual", "JA klientas", "Spain", 30, "Paðilës 37", false, true);

            double price = 100;

            var calculator = new InvoiceW();

            Assert.Equal(0, calculator.VATcalculatorCompany(client, Provider, price), 0);
        }


        [Fact]
        public void Provider_is_VAT_Payer_Client_Lives_EU_NOT_VAT_Payer_Diffirent_Country_Return_21()
        {
            var Provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Individual("356566", "individual", "JA klientas", "Spain", 30, "Paðilës 37", true, false);

            double price = 100;

            var calculator = new InvoiceW();

            Assert.Equal(21, calculator.VATcalculatorIndividual(client, Provider, price), 0);
        }

        [Fact]
        public void Provider_is_VAT_Payer_Client_Lives_EU_IS_VAT_Payer_Diffirent_Country_Return_0()
        {
            var Provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Company("356566", "individual", "JA klientas", "Spain", 30, "Paðilës 37", true, true);

            double price = 100;

            var calculator = new InvoiceW();

            Assert.Equal(0, calculator.VATcalculatorCompany(client, Provider, price), 0);
        }

        [Fact]
        public void Provider_is_VAT_Payer_Lives_Same_Country_Return_21()
        {
            var Provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Company("356566", "individual", "JA klientas", "Lithuania", 21, "Paðilës 37", true, true);

            double price = 100;

            var calculator = new InvoiceW();

            Assert.Equal(21, calculator.VATcalculatorCompany(client, Provider, price), 0);
        }



    }
}
