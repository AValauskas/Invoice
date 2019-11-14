using System;
using Xunit;
using Invoice.Begin.Invoice;
using Invoice.Begin.Calculate;
using Invoice.Begin.People;
using Invoice.Begin.Union;
using NSubstitute;


namespace InvoiceTests
{
    public class InvoiceVatPriceTestsIntern
    {
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_outside_EU_return_50()
        {
            IInvoiceCalculator invoice = new InvoiceCalculator();

            var provider = new Provider(new Country ("LT", 21), new Company("Company"));
            var customer = new Customer("Customer", new Country("ZE", 25), false);
            var order = new Order(50);
            invoice.CountryProvider = Substitute.For<ICountryInfoProvider>();
            invoice.CountryProvider.IsEurope("LT").Returns(true);
            invoice.CountryProvider.IsEurope("ZE").Returns(false);

            Assert.Equal(50, invoice.Calculate(customer, provider, order), 0);
        }
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_outside_EU_return_1500()
        {
            IInvoiceCalculator invoice = new InvoiceCalculator();

            var provider = new Provider(new Country("DE", 19), new Company("Company"));
            var customer = new Customer(new Country("JAV", 11), new Company("comp"));
            var order = new Order(1500);
            var infoprovider = Substitute.For<ICountryInfoProvider>();
            infoprovider.IsEurope("DE").Returns(true);
            infoprovider.IsEurope("JAV").Returns(false);
            invoice.CountryProvider = infoprovider;
            Assert.Equal(1500, invoice.Calculate(customer, provider, order), 0);
        }


        
        //---------------------------------------------------------------------------------------------------
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_25()
        {
            IInvoiceCalculator invoice = new InvoiceCalculator();

            var provider = new Provider(new Country("LT", 21), new Company("Company"));
            var customer = new Customer("Customer", new Country("SE", 25), false);
            var order = new Order(20);

            invoice.CountryProvider= Substitute.For<ICountryInfoProvider>();
            invoice.CountryProvider.IsEurope("LT").Returns(true);
            invoice.CountryProvider.IsEurope("SE").Returns(true);
            Assert.Equal(25, invoice.Calculate(customer, provider, order), 0);
        }
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_2460()
        {
            IInvoiceCalculator invoice = new InvoiceCalculator();

            var provider = new Provider(new Country("LT", 21), new Company("Company"));
            var customer = new Customer("Customer", new Country("FL", 23), false);
            var order = new Order(2000);

            invoice.CountryProvider = Substitute.For<ICountryInfoProvider>();
            invoice.CountryProvider.IsEurope("LT").Returns(true);
            invoice.CountryProvider.IsEurope("FL").Returns(true);
            Assert.Equal(2460, invoice.Calculate(customer, provider, order), 0);
        }
        //-------------------------------------------------------------------------------------
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Different_countries_return_1000()
        {
            IInvoiceCalculator invoice = new InvoiceCalculator();

            var provider = new Provider(new Country("LT", 21), new Company("Company"));
            var customer = new Customer(new Country("SE", 25), new Company("Customer company"));
            var order = new Order(1000);

            invoice.CountryProvider = Substitute.For<ICountryInfoProvider>();
            invoice.CountryProvider.IsEurope("LT").Returns(true);
            invoice.CountryProvider.IsEurope("SE").Returns(true);


            Assert.Equal(1000, invoice.Calculate(customer, provider, order), 0);
        }

        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Different_countries_return_5000()
        {
            IInvoiceCalculator invoice = new InvoiceCalculator();

            var provider = new Provider( new Country("LT", 21), new Company("Company"));
            var customer = new Customer("Customer", new Country("FL", 23), true);
            var order = new Order(5000);

            invoice.CountryProvider = Substitute.For<ICountryInfoProvider>();
            invoice.CountryProvider.IsEurope("LT").Returns(true);
            invoice.CountryProvider.IsEurope("FL").Returns(true);

            Assert.Equal(5000, invoice.Calculate(customer, provider, order), 0);
        }

        //-------------------------------------------------------------------------
        
[Fact]
public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Same_countries_return_1210()
{
    IInvoiceCalculator invoice = new InvoiceCalculator();

    var provider = new Provider(new Country("LT", 21), new Company("Company"));
    var customer = new Customer(new Country("LT", 21), new Company("Customer company"));
    var order = new Order(1000);

            invoice.CountryProvider = Substitute.For<ICountryInfoProvider>();
            invoice.CountryProvider.IsEurope("LT").Returns(true);

    Assert.Equal(1210, invoice.Calculate(customer, provider, order), 0);
}
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Same_countries_return_7320()
        {
            IInvoiceCalculator invoice = new InvoiceCalculator();

            var provider = new Provider(new Country("IT", 22), new Company("Company"));
            var customer = new Customer(new Country("IT", 22), new Company("Customer company"));
            var order = new Order(6000);

            invoice.CountryProvider = Substitute.For<ICountryInfoProvider>();
            invoice.CountryProvider.IsEurope("IT").Returns(true);

            Assert.Equal(7320, invoice.Calculate(customer, provider, order), 0);
        }

        
    }
}
