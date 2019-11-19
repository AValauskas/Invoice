using System;
using Xunit;
using Invoice.Begin.Invoice;
using Invoice.Begin.Calculate;
using Invoice.Begin.People;
using Invoice.Begin.Union;
using NSubstitute;



namespace oneMoreTesting
{

    public class UsersFixure : IDisposable
    {

        //Providers
        public static readonly Provider ProviderIsVATPayerFomLT = new Provider(new Country("LT"), new Company("Company"));

        public static readonly Provider ProviderIsVATPayerFomIT = new Provider(new Country("IT"), new Company("Company"));

        public static readonly Provider ProviderIsVATPayerFomDE = new Provider(new Country("DE"), new Company("Company"));



        //Customer outside EU
        public static readonly Customer CustomerOutsideEUZE = new Customer("Customer", new Country("ZE"), false);

        public static readonly Customer CustomerOutsideEUJAV = new Customer(new Country("JAV"), new Company("comp"));



        //Customer in EU Pay VAT
        public static readonly Customer CustomerInEUSEPayVAT = new Customer(new Country("SE"), new Company("Customer company"));

        public static readonly Customer CustomerInEUFLPayVAT = new Customer(new Country("FL"), new Company("Customer company"));

        public static readonly Customer CustomerInEULTPayVAT = new Customer(new Country("LT"), new Company("Customer company"));

        public static readonly Customer CustomerInEUITPayVAT = new Customer(new Country("IT"), new Company("Customer company"));


        //customer in eu dont pay VAT
        public static readonly Customer CustomerInEUSE = new Customer("Customer", new Country("SE"), false);

        public static readonly Customer CustomerInEUFL = new Customer("Customer", new Country("FL"), false);

        public void Dispose()
        {
            // clean up test data after each tests
        }
    }


    public class InvoiceTesting : IClassFixture<UsersFixure>
    {
        UsersFixure userFixture;

        public InvoiceTesting(UsersFixure fixture)
        {
            this.userFixture = fixture;
        }
        
      //  public MethodForMocks()



        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_outside_EU_return_50()
        {
            var calculator = new InvoiceCalculator();
            //   CustomerOrderServiceTests cus= new CustomerOrderServiceTests();
            var provider = UsersFixure.ProviderIsVATPayerFomLT;
            var customer = UsersFixure.CustomerOutsideEUZE;
            var order = new Order(50);

            var mockIsEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsEuropeanUnion.IsEurope(provider).Returns(true);
            mockIsEuropeanUnion.IsEurope(customer).Returns(false);
            calculator.CountryProvider = mockIsEuropeanUnion;

            var MockVatGetter = Substitute.For<IVatGetter>();
            MockVatGetter.GetVAT(provider).Returns(21);
            MockVatGetter.GetVAT(customer).Returns(25);
            calculator.VATGetter = MockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(50, result);
        }
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_outside_EU_return_1500()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixure.ProviderIsVATPayerFomDE;
            var customer = UsersFixure.CustomerOutsideEUJAV;
            var order = new Order(1500);


            var mockIsEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsEuropeanUnion.IsEurope(provider).Returns(true);
            mockIsEuropeanUnion.IsEurope(customer).Returns(false);
            calculator.CountryProvider = mockIsEuropeanUnion;

            var MockVatGetter = Substitute.For<IVatGetter>();
            MockVatGetter.GetVAT(provider).Returns(19);
            MockVatGetter.GetVAT(customer).Returns(11);
            calculator.VATGetter = MockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(1500, result);
        }


        
        //---------------------------------------------------------------------------------------------------
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_25()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixure.ProviderIsVATPayerFomLT;
            var customer = UsersFixure.CustomerInEUSE;
            var order = new Order(20);

            var mockIsEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsEuropeanUnion.IsEurope(provider).Returns(true);
            mockIsEuropeanUnion.IsEurope(customer).Returns(true);
            calculator.CountryProvider = mockIsEuropeanUnion;

            var MockVatGetter = Substitute.For<IVatGetter>();
            MockVatGetter.GetVAT(provider).Returns(21);
            MockVatGetter.GetVAT(customer).Returns(25);
            calculator.VATGetter = MockVatGetter;


            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(25, result);
        }
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_2460()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixure.ProviderIsVATPayerFomLT;
            var customer = UsersFixure.CustomerInEUFL;
            var order = new Order(2000);

            var mockIsEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsEuropeanUnion.IsEurope(provider).Returns(true);
            mockIsEuropeanUnion.IsEurope(customer).Returns(true);
            calculator.CountryProvider = mockIsEuropeanUnion;

            var MockVatGetter = Substitute.For<IVatGetter>();
            MockVatGetter.GetVAT(provider).Returns(21);
            MockVatGetter.GetVAT(customer).Returns(23);
            calculator.VATGetter = MockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(2460, result);
        }
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_2000()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixure.ProviderIsVATPayerFomLT;
            var customer = UsersFixure.CustomerInEUFL;
            var order = new Order(2000);

            var mockIsEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsEuropeanUnion.IsEurope(provider).Returns(true);
            mockIsEuropeanUnion.IsEurope(customer).Returns(true);
            calculator.CountryProvider = mockIsEuropeanUnion;

            var MockVatGetter = Substitute.For<IVatGetter>();
            MockVatGetter.GetVAT(provider).Returns(21);
            MockVatGetter.GetVAT(customer).Returns(23);
            calculator.VATGetter = MockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.NotEqual(2000, result);
        }
        //-------------------------------------------------------------------------------------
      
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Different_countries_return_1000()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixure.ProviderIsVATPayerFomLT;
            var customer = UsersFixure.CustomerInEUSEPayVAT;
            var order = new Order(1000);

            var mockIsEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsEuropeanUnion.IsEurope(provider).Returns(true);
            mockIsEuropeanUnion.IsEurope(customer).Returns(true);
            calculator.CountryProvider = mockIsEuropeanUnion;

            var MockVatGetter = Substitute.For<IVatGetter>();
            MockVatGetter.GetVAT(provider).Returns(21);
            MockVatGetter.GetVAT(customer).Returns(25);
            calculator.VATGetter = MockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(1000, result);
        }
        
      [Fact]
      public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Different_countries_return_5000()
      {
          IInvoiceCalculator calculator = new InvoiceCalculator();

          var provider = UsersFixure.ProviderIsVATPayerFomLT;
          var customer = UsersFixure.CustomerInEUFLPayVAT;
          var order = new Order(5000);

            var mockIsEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsEuropeanUnion.IsEurope(provider).Returns(true);
            mockIsEuropeanUnion.IsEurope(customer).Returns(true);
            calculator.CountryProvider = mockIsEuropeanUnion;

            var MockVatGetter = Substitute.For<IVatGetter>();
            MockVatGetter.GetVAT(provider).Returns(21);
            MockVatGetter.GetVAT(customer).Returns(23);
            calculator.VATGetter = MockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
          Assert.Equal(5000, result);
      }

        //-------------------------------------------------------------------------
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Same_countries_return_1210()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixure.ProviderIsVATPayerFomLT;
            var customer = UsersFixure.CustomerInEULTPayVAT;
            var order = new Order(1000);

            var mockIsEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsEuropeanUnion.IsEurope(provider).Returns(true);
            mockIsEuropeanUnion.IsEurope(customer).Returns(true);
            calculator.CountryProvider = mockIsEuropeanUnion;

            var MockVatGetter = Substitute.For<IVatGetter>();
            MockVatGetter.GetVAT(provider).Returns(21);
            MockVatGetter.GetVAT(customer).Returns(21);
            calculator.VATGetter = MockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(1210, result);
        }

        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Same_countries_return_7320()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixure.ProviderIsVATPayerFomIT;
            var customer = UsersFixure.CustomerInEUITPayVAT;
            var order = new Order(6000);

            var mockIsEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsEuropeanUnion.IsEurope(provider).Returns(true);
            mockIsEuropeanUnion.IsEurope(customer).Returns(true);
            calculator.CountryProvider = mockIsEuropeanUnion;

            var MockVatGetter = Substitute.For<IVatGetter>();
            MockVatGetter.GetVAT(provider).Returns(22);
            MockVatGetter.GetVAT(customer).Returns(22);
            calculator.VATGetter = MockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(7320, result);
        }
        
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Same_countries_return_6000()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixure.ProviderIsVATPayerFomIT;
            var customer = UsersFixure.CustomerInEUITPayVAT;
            var order = new Order(6000);

            var mockIsEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsEuropeanUnion.IsEurope(provider).Returns(true);
            mockIsEuropeanUnion.IsEurope(customer).Returns(true);
            calculator.CountryProvider = mockIsEuropeanUnion;

            var MockVatGetter = Substitute.For<IVatGetter>();
            MockVatGetter.GetVAT(provider).Returns(22);
            MockVatGetter.GetVAT(customer).Returns(22);
            calculator.VATGetter = MockVatGetter;

            var result = calculator.Calculate(customer, provider, order);
            Assert.NotEqual(6000, result, 0);
        }
        
        //[SetUp]
        [Fact]
        public void ICalculator_InTerface_NotGiven_null_Point_exeption()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixure.ProviderIsVATPayerFomIT;
            var customer = UsersFixure.CustomerInEUITPayVAT;
            var order = new Order(6000);


            var mockIsEuropeanUnion = Substitute.For<ICountryInfoProvider>();
            mockIsEuropeanUnion.IsEurope(provider).Returns(X => { throw new Exception(); });
            mockIsEuropeanUnion.IsEurope(customer).Returns(X => { throw new Exception(); });
            calculator.CountryProvider = mockIsEuropeanUnion;

            var MockVatGetter = Substitute.For<IVatGetter>();
            MockVatGetter.GetVAT(provider).Returns(X => { throw new Exception(); });
            MockVatGetter.GetVAT(customer).Returns(X => { throw new Exception(); });
            calculator.VATGetter = MockVatGetter;

            // var result = calculator.Calculate(customer, provider, order);
            Assert.Throws<Exception>(() => calculator.Calculate(customer, provider, order));
        }
        public void Dispose()
        {
            // Clean stuff that is not needed anymore, such as things in database and etc.
        }
    }
    
}
