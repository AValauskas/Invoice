using System;
using Xunit;
using Invoice.Begin.Invoice;
using Invoice.Begin.Calculate;
using Invoice.Begin.People;
using Invoice.Begin.Union;
using NSubstitute;
using Testing.datasets;


namespace Testing
{
  

    public class InvoiceVatPriceIntern : IDisposable
    {
        //Providers
        public readonly Provider ProviderIsVATPayerFomLT = new Provider(new Country("LT"), new Company("Company"));

        public readonly Provider ProviderIsVATPayerFomIT = new Provider(new Country("IT"), new Company("Company"));

        public readonly Provider ProviderIsVATPayerFomDE = new Provider(new Country("DE"), new Company("Company"));



        //Customer outside EU
        public readonly Customer CustomerOutsideEUZE = new Customer("Customer", new Country("ZE"), false);

        public readonly Customer CustomerOutsideEUJAV = new Customer(new Country("JAV"), new Company("comp"));



        //Customer in EU Pay VAT
        public readonly Customer CustomerInEUSEPayVAT = new Customer(new Country("SE"), new Company("Customer company"));

        public readonly Customer CustomerInEUFLPayVAT = new Customer(new Country("FL"), new Company("Customer company"));

        public readonly Customer CustomerInEULTPayVAT = new Customer(new Country("LT"), new Company("Customer company"));

        public readonly Customer CustomerInEUITPayVAT = new Customer(new Country("IT"), new Company("Customer company"));


        //customer in eu dont pay VAT
        public readonly Customer CustomerInEUSE = new Customer("Customer", new Country("SE"), false);

        public readonly Customer CustomerInEUFL = new Customer("Customer", new Country("FL"), false);
        /*
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_outside_EU_return_50()
        {
            var calculator = new InvoiceCalculator();
            //   CustomerOrderServiceTests cus= new CustomerOrderServiceTests();
            var provider = ProviderIsVATPayerFomLT;
            var customer = CustomerOutsideEUZE;
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

            var provider = ProviderIsVATPayerFomDE;
            var customer = CustomerOutsideEUJAV;
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

            var provider = ProviderIsVATPayerFomLT;
            var customer = CustomerInEUSE;
            var order = new Order(20);

            var mock = Substitute.For<ICountryInfoProvider>();
            mock.IsEurope("LT").Returns(true);
            mock.IsEurope("SE").Returns(true);
            calculator.CountryProvider = mock;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(25, result, 0);
        }

        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_2460()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = ProviderIsVATPayerFomLT;
            var customer = CustomerInEUFL;
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

            var provider = ProviderIsVATPayerFomLT;
            var customer = CustomerInEUFL;
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

            var provider = ProviderIsVATPayerFomLT;
            var customer = CustomerInEUSEPayVAT;
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

            var provider = ProviderIsVATPayerFomLT;
            var customer = CustomerInEUFLPayVAT;
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

            var provider = ProviderIsVATPayerFomLT;
            var customer = CustomerInEULTPayVAT;
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

            var provider = ProviderIsVATPayerFomIT;
            var customer = CustomerInEUITPayVAT;
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

            var provider = ProviderIsVATPayerFomIT;
            var customer = CustomerInEUITPayVAT;
            var order = new Order(6000);

            var mock = Substitute.For<ICountryInfoProvider>();
            mock.IsEurope("IT").Returns(true);
            calculator.CountryProvider = mock;

            var result = calculator.Calculate(customer, provider, order);
            Assert.NotEqual(6000, result, 0);
        }

        //[SetUp]
        [Fact]
        public void ICalculator_InTerface_NotGiven_null_Point_exeption()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = ProviderIsVATPayerFomIT;
            var customer = CustomerInEUITPayVAT;
            var order = new Order(6000);

             var mock = Substitute.For<ICountryInfoProvider>();
             mock.IsEurope("IT").Returns(X => { throw new Exception(); });
             calculator.CountryProvider = mock;


           // var result = calculator.Calculate(customer, provider, order);
            Assert.Throws<Exception>(() => calculator.Calculate(customer, provider, order));
        }*/
        public void Dispose()
        {
            // Clean stuff that is not needed anymore, such as things in database and etc.
        }
        
    }

}
