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
            var calculator = new InvoiceCalculator();
            
            var provider = new Provider(new Country ("LT", 21), new Company("Company"));
            var customer = new Customer("Customer", new Country("ZE", 25), false);
            var order = new Order(50);

            var mock = Substitute.For<ICountryInfoProvider>();
            mock.IsEurope("LT").Returns(true);
            mock.IsEurope("ZE").Returns(false);
            calculator.CountryProvider = mock;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(50, result, 0);
        }
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_outside_EU_return_1500()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = new Provider(new Country("DE", 19), new Company("Company"));
            var customer = new Customer(new Country("JAV", 11), new Company("comp"));
            var order = new Order(1500);

            var mock = Substitute.For<ICountryInfoProvider>();
            mock.IsEurope("DE").Returns(true);
            mock.IsEurope("JAV").Returns(false);
            calculator.CountryProvider = mock;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(1500, result, 0);
        }


        
        //---------------------------------------------------------------------------------------------------
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_25()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = new Provider(new Country("LT", 21), new Company("Company"));
            var customer = new Customer("Customer", new Country("SE", 25), false);
            var order = new Order(20);

            var mock= Substitute.For<ICountryInfoProvider>();
            mock.IsEurope("LT").Returns(true);
            mock.IsEurope("SE").Returns(true);
            calculator.CountryProvider = mock;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(25,result, 0);
        }
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_2460()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = new Provider(new Country("LT", 21), new Company("Company"));
            var customer = new Customer("Customer", new Country("FL", 23), false);
            var order = new Order(2000);

            var mock = Substitute.For<ICountryInfoProvider>();
            mock.IsEurope("LT").Returns(true);
            mock.IsEurope("FL").Returns(true);
            calculator.CountryProvider = mock;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(2460, result, 0);
        }

        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_2000()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = new Provider(new Country("LT", 21), new Company("Company"));
            var customer = new Customer("Customer", new Country("FL", 23), false);
            var order = new Order(2000);

            var mock = Substitute.For<ICountryInfoProvider>();
            mock.IsEurope("LT").Returns(true);
            mock.IsEurope("FL").Returns(true);
            calculator.CountryProvider = mock;

            var result = calculator.Calculate(customer, provider, order);
            Assert.NotEqual(2000, result, 0);
        }
        //-------------------------------------------------------------------------------------

        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Different_countries_return_1000()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = new Provider(new Country("LT", 21), new Company("Company"));
            var customer = new Customer(new Country("SE", 25), new Company("Customer company"));
            var order = new Order(1000);

            var mock = Substitute.For<ICountryInfoProvider>();
            mock.IsEurope("LT").Returns(true);
            mock.IsEurope("SE").Returns(true);
            calculator.CountryProvider = mock;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(1000, result, 0);
        }

        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Different_countries_return_5000()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = new Provider( new Country("LT", 21), new Company("Company"));
            var customer = new Customer("Customer", new Country("FL", 23), true);
            var order = new Order(5000);

            var mock = Substitute.For<ICountryInfoProvider>();
            mock.IsEurope("LT").Returns(true);
            mock.IsEurope("FL").Returns(true);
            calculator.CountryProvider = mock;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(5000, result, 0);
        }

        //-------------------------------------------------------------------------
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Same_countries_return_1210()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = new Provider(new Country("LT", 21), new Company("Company"));
            var customer = new Customer(new Country("LT", 21), new Company("Customer company"));
            var order = new Order(1000);

            var mock = Substitute.For<ICountryInfoProvider>();
            mock.IsEurope("LT").Returns(true);
            calculator.CountryProvider = mock;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(1210, result, 0);
        }
        

        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Same_countries_return_7320()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = new Provider(new Country("IT", 22), new Company("Company"));
            var customer = new Customer(new Country("IT", 22), new Company("Customer company"));
            var order = new Order(6000);

            var mock = Substitute.For<ICountryInfoProvider>();
            mock.IsEurope("IT").Returns(true);
            calculator.CountryProvider = mock;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(7320, result, 0);
        }
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Same_countries_return_6000()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = new Provider(new Country("IT", 22), new Company("Company"));
            var customer = new Customer(new Country("IT", 22), new Company("Customer company"));
            var order = new Order(6000);

            var mock = Substitute.For<ICountryInfoProvider>();
            mock.IsEurope("IT").Returns(true);
            calculator.CountryProvider = mock;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(7320, result, 0);
        }

    }
}
