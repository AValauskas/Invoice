using System;
using Xunit;
//using Invoice.Begin.Invoice;
using Invoice.Begin.Calculate;
using Invoice.Begin.People;
using Invoice.Begin.Union;
using NSubstitute;
using Invoice.Begin;

namespace oneMoreTesting
{

    public class UsersFixture : IDisposable
    {

        //Providers
        public static readonly Provider ProviderIsVATPayerFomLT = new Provider(new Country("LT"), new Company("Company",true));

        public static readonly Provider ProviderIsVATPayerFomLTNOTVATPayer = new Provider(new Country("LT"), new Company("Company", false));

        public static readonly Provider ProviderIsVATPayerFomIT = new Provider(new Country("IT"), new Company("Company", true));

        public static readonly Provider ProviderIsVATPayerFomDE = new Provider(new Country("DE"), new Company("Company", true));

        public static readonly Provider ProviderIsVATPayerFomJAV = new Provider(new Country("JAV"), new Company("Company", true));

        //Customer outside EU
        public static readonly Customer CustomerOutsideEUZE = new Customer("Customer", new Country("ZE"));

        public static readonly Customer CustomerOutsideEUJAV = new Customer(new Country("JAV"), new Company("comp", true));



        //Customer in EU Pay VAT
        public static readonly Customer CustomerInEUSEPayVAT = new Customer(new Country("SE"), new Company("Customer company", true));

        public static readonly Customer CustomerInEUFLPayVAT = new Customer(new Country("FL"), new Company("Customer company", true));

        public static readonly Customer CustomerInEULTPayVAT = new Customer(new Country("LT"), new Company("Customer company", true));

        public static readonly Customer CustomerInEUITPayVAT = new Customer(new Country("IT"), new Company("Customer company", true));

        public static readonly Customer CustomerInEULTDontPayVAT = new Customer(new Country("LT"), new Company("Customer company", false));

        public static readonly Customer CustomerInEUITDontPayVAT = new Customer(new Country("IT"), new Company("Customer company", false));
        //customer in eu dont pay VAT
        public static readonly Customer CustomerInEUSE = new Customer("Customer", new Country("SE"));

        public static readonly Customer CustomerInEUFL = new Customer("Customer", new Country("FL"));

        public void Dispose()
        {
            // clean up test data after each tests
        }
    }


    public class InvoiceTesting : IClassFixture<UsersFixture>
    {
        UsersFixture userFixture;

        public InvoiceTesting(UsersFixture fixture)
        {
            this.userFixture = fixture;
        }

        [Fact]
        public void Provider_NOY_VAT_Payer_150()
        {
            var calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomLTNOTVATPayer;
            var customer = UsersFixture.CustomerOutsideEUZE;
            var order = new Order(150);

            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(false);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(true);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var mockVatGetter = Substitute.For<IVatGetter>();
            mockVatGetter.GetVAT(provider.GetCountry()).Returns(21);
            mockVatGetter.GetVAT(customer.GetCountry()).Returns(25);
            calculator.VATGetter = mockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(150, result);
        }


        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_outside_EU_return_50()
        {
            var calculator = new InvoiceCalculator();
           
            var provider = UsersFixture.ProviderIsVATPayerFomLT;
            var customer = UsersFixture.CustomerOutsideEUZE;
            var order = new Order(50);

            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(true);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(false);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var mockVatGetter = Substitute.For<IVatGetter>();
            mockVatGetter.GetVAT(provider.GetCountry()).Returns(21);
            mockVatGetter.GetVAT(customer.GetCountry()).Returns(25);
            calculator.VATGetter = mockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(50, result);
        }
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_outside_EU_return_1500()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomDE;
            var customer = UsersFixture.CustomerOutsideEUJAV;
            var order = new Order(1500);


            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(true);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(false);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var mockVatGetter = Substitute.For<IVatGetter>();
            mockVatGetter.GetVAT(provider.GetCountry()).Returns(19);
            mockVatGetter.GetVAT(customer.GetCountry()).Returns(11);
            calculator.VATGetter = mockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(1500, result);
        }


        
        //---------------------------------------------------------------------------------------------------
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_121()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomLT;
            var customer = UsersFixture.CustomerInEUSE;
            var order = new Order(100);

            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(true);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(true);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var mockVatGetter = Substitute.For<IVatGetter>();
            mockVatGetter.GetVAT(provider.GetCountry()).Returns(21);
            mockVatGetter.GetVAT(customer.GetCountry()).Returns(25);
            calculator.VATGetter = mockVatGetter;


            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(121, result);
        }

        /*  [Fact]
          public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_2220()
          {
              IInvoiceCalculator calculator = new InvoiceCalculator();

              var provider = UsersFixture.ProviderIsVATPayerFomJAV;
              var customer = UsersFixture.CustomerInEUFL;
              var order = new Order(2000);

              var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
              mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(false);
              mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(true);
              calculator.CountryProvider = mockIsInEuropeanUnion;

              var mockVatGetter = Substitute.For<IVatGetter>();
              mockVatGetter.GetVAT(provider.GetCountry()).Returns(11);
              mockVatGetter.GetVAT(customer.GetCountry()).Returns(23);
              calculator.VATGetter = mockVatGetter;

              var result = calculator.Calculate(customer, provider, order);
              Assert.Equal(2220, result);
          }
          */
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_2000()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomLT;
            var customer = UsersFixture.CustomerInEUFL;
            var order = new Order(2000);

            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(true);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(true);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var mockVatGetter = Substitute.For<IVatGetter>();
            mockVatGetter.GetVAT(provider.GetCountry()).Returns(21);
            mockVatGetter.GetVAT(customer.GetCountry()).Returns(23);
            calculator.VATGetter = mockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.NotEqual(2000, result);
        }
        //-------------------------------------------------------------------------------------
      
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Different_countries_return_1000()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomLT;
            var customer = UsersFixture.CustomerInEUSEPayVAT;
            var order = new Order(1000);

            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(true);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(true);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var mockVatGetter = Substitute.For<IVatGetter>();
            mockVatGetter.GetVAT(provider.GetCountry()).Returns(21);
            mockVatGetter.GetVAT(customer.GetCountry()).Returns(25);
            calculator.VATGetter = mockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(1000, result);
        }
        
      [Fact]
      public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Different_countries_return_5000()
      {
          IInvoiceCalculator calculator = new InvoiceCalculator();

          var provider = UsersFixture.ProviderIsVATPayerFomLT;
          var customer = UsersFixture.CustomerInEUFLPayVAT;
          var order = new Order(5000);

            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(true);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(true);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var mockVatGetter = Substitute.For<IVatGetter>();
            mockVatGetter.GetVAT(provider.GetCountry()).Returns(21);
            mockVatGetter.GetVAT(customer.GetCountry()).Returns(23);
            calculator.VATGetter = mockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
          Assert.Equal(5000, result);
      }

        //-------------------------------------------------------------------------
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Same_countries_return_1210()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomLT;
            var customer = UsersFixture.CustomerInEULTPayVAT;
            var order = new Order(1000);

            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(true);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(true);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var mockVatGetter = Substitute.For<IVatGetter>();
            mockVatGetter.GetVAT(provider.GetCountry()).Returns(21);
            mockVatGetter.GetVAT(customer.GetCountry()).Returns(21);
            calculator.VATGetter = mockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(1210, result);
        }

        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Same_countries_return_7320()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomIT;
            var customer = UsersFixture.CustomerInEUITPayVAT;
            var order = new Order(6000);

            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(true);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(true);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var mockVatGetter = Substitute.For<IVatGetter>();
            mockVatGetter.GetVAT(provider.GetCountry()).Returns(22);
            mockVatGetter.GetVAT(customer.GetCountry()).Returns(22);
            calculator.VATGetter = mockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(7320, result);
        }
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Same_countries_return_6000()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomIT;
            var customer = UsersFixture.CustomerInEUITPayVAT;
            var order = new Order(6000);

            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(true);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(true);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var mockVatGetter = Substitute.For<IVatGetter>();
            mockVatGetter.GetVAT(provider.GetCountry()).Returns(22);
            mockVatGetter.GetVAT(customer.GetCountry()).Returns(22);
            calculator.VATGetter = mockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.NotEqual(6000, result, 0);
        }
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_outside_EU_pay_VAT_Same_countries_return_6000()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomJAV;
            var customer = UsersFixture.CustomerOutsideEUJAV;
            var order = new Order(6000);

            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(false);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(false);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var mockVatGetter = Substitute.For<IVatGetter>();
            mockVatGetter.GetVAT(provider.GetCountry()).Returns(11);
            mockVatGetter.GetVAT(customer.GetCountry()).Returns(11);
            calculator.VATGetter = mockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.NotEqual(6000, result, 0);
        }

    
        [Fact]
        public void ICalculator_InTerface_Provider_Not_EU_Exception()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomJAV;
            var customer = UsersFixture.CustomerInEUITPayVAT;
            var order = new Order(6000);

            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(false);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(true);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var message = "Not Specified VATGetter";

            var exception = Assert.Throws<BussinessException>(() => calculator.Calculate(customer, provider, order)); 
            Assert.Equal(message, exception.Message);
        }
        [Fact]
        public void ICalculator_InTerface_Provider_VAT_NOT_fount()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomJAV;
            var customer = UsersFixture.CustomerInEUITPayVAT;
            var order = new Order(6000);

            var mockIsInEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsInEuropeanUnion.IsInEurope(provider.GetCountry()).Returns(true);
            mockIsInEuropeanUnion.IsInEurope(customer.GetCountry()).Returns(true);
            calculator.CountryProvider = mockIsInEuropeanUnion;

            var mockVatGetter = Substitute.For<IVatGetter>();
            mockVatGetter.GetVAT(provider.GetCountry()).Returns(0);
            mockVatGetter.GetVAT(customer.GetCountry()).Returns(22);
            calculator.VATGetter = mockVatGetter;

            var message = "Provider VAT were not found, edit your Country VAT list";

            var exception = Assert.Throws<BussinessException>(() => calculator.Calculate(customer, provider, order));
            Assert.Equal(message, exception.Message);
        }





       
        public void Dispose()
        {
            // Clean stuff that is not needed anymore, such as things in database and etc.
        }
    }
    
}
