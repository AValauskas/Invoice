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
        public void Provider_IS_VAT_Payer_Client_lives_outside_EU_return_0()
        {

            IInvoiceCalculator invoice = new Calculator();

            var provider = new Provider("UAB tiekëjas",new Country ("LT", 21), new Company("Company"));

            var customer = new Customer("Customer", new Country("ZE", 26), new Company("Customer Company"));

            var order = new Order(15);



          //  var providerTasks = Substitute.For<Provider>();
          //  var customerTasks = Substitute.For<Customer>();
            var IsEU = Substitute.For<IIsEuropeanUnion>();

            
           // providerTasks.GetCountry().Returns(new Country("LT",21));
            //.GetCountry().Returns(new Country("ZE", 26));

            IsEU.IsEurope("LT").Returns(true);
            IsEU.IsEurope("ZE").Returns(true);

            double VAT = invoice.Calculate(customer, provider, order, IsEU);
            Assert.Equal(26, VAT, 0);
             // Assert.True(IsEU.IsEurope("LT"));
        }
        /*
        [Fact]
        public void ProviderControler_WriteInvoiceCompany_Provider_is_VAT_Payer_Client_NOT_EU_Return_0()
        {
            ProviderController provController = new ProviderController();
            var provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Company("356566", "company", "JA klientas", "Spain", 30, "Paðilës 37", false, true);

            double price = 100;

            var providertasks = Substitute.For<Provider>();
            var companytasks = Substitute.For<Company>();

            providertasks.Login().Returns(provider);
            providertasks.getPrice().Returns(100);
            companytasks.GetCompany().Returns(client);
            double PVM = provController.WriteInvoiceCompany(providertasks, companytasks);

            Assert.Equal(0, PVM, 0);
        }
        [Fact]
        public void ProviderControler_WriteInvoiceCompany_Provider_is_VAT_Payer_Client_Lives_EU_NOT_VAT_Payer_Diffirent_Country_Return_21()
        {
            ProviderController provController = new ProviderController();
            var provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Company("356566", "company", "comp", "Spain", 30, "Paðilës 37", true, false);

            double price = 100;


            var providertasks = Substitute.For<Provider>();
            var companytasks = Substitute.For<Company>();

            providertasks.Login().Returns(provider);
            providertasks.getPrice().Returns(100);
            companytasks.GetCompany().Returns(client);
            double PVM = provController.WriteInvoiceCompany(providertasks, companytasks);

            Assert.Equal(21, PVM, 0);
        }
        [Fact]
        public void ProviderControler_WriteInvoiceCompany_Provider_is_VAT_Payer_Client_Lives_EU_IS_VAT_Payer_Diffirent_Country_Return_0()
        {
            ProviderController provController = new ProviderController();
            var provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Company("356566", "company", "JA klientas", "Spain", 30, "Paðilës 37", true, true);

            double price = 100;


            var providertasks = Substitute.For<Provider>();
            var companytasks = Substitute.For<Company>();

            providertasks.Login().Returns(provider);
            providertasks.getPrice().Returns(100);
            companytasks.GetCompany().Returns(client);
            double PVM = provController.WriteInvoiceCompany(providertasks, companytasks);

            Assert.Equal(0, PVM, 0);
        }
        [Fact]
        public void ProviderControler_WriteInvoiceCompany_Provider_is_VAT_Payer_Lives_Same_Country_Return_21()
        {
            ProviderController provController = new ProviderController();
            var provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Company("356566", "company", "JA klientas", "Lithuania", 21, "Paðilës 37", true, true);

            double price = 100;


            var providertasks = Substitute.For<Provider>();
            var companytasks = Substitute.For<Company>();

            providertasks.Login().Returns(provider);
            providertasks.getPrice().Returns(100);
            companytasks.GetCompany().Returns(client);
            double PVM = provController.WriteInvoiceCompany(providertasks, companytasks);

            Assert.Equal(21, PVM, 0);
        }







        [Fact]
        public void ProviderControler_WriteInvoiceIndividual_Provider_Not_VAT_Payer_Return0()
        {
            ProviderController provController = new ProviderController();

            var provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", false);

            var client = new Individual("356566", "individual", "uab Rab", "Spain", 30, "37", true, true);

            double price = 100;
            var providertasks = Substitute.For<Provider>();
            var personTasks = Substitute.For<Individual>();

            providertasks.Login().Returns(provider);
            providertasks.getPrice().Returns(100);
            personTasks.GetPerson().Returns(client);

            double PVM = provController.WriteInvoiceIndividual(providertasks, personTasks);

            Assert.Equal(0, PVM, 0);
        }
        [Fact]
        public void ProviderControler_WriteInvoiceIndividual_Provider_is_VAT_Payer_Client_NOT_EU_Return_0()
        {
            ProviderController provController = new ProviderController();
            var provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Individual("356566", "individual", "JA klientas", "Spain", 30, "Paðilës 37", false, true);

            double price = 100;
            var providertasks = Substitute.For<Provider>();
            var personTasks = Substitute.For<Individual>();

            providertasks.Login().Returns(provider);
            providertasks.getPrice().Returns(100);
            personTasks.GetPerson().Returns(client);

            double PVM = provController.WriteInvoiceIndividual(providertasks, personTasks);

            Assert.Equal(0, PVM, 0);
        }
        [Fact]
        public void ProviderControler_WriteInvoiceIndividual_Provider_is_VAT_Payer_Client_Lives_EU_NOT_VAT_Payer_Diffirent_Country_Return_21()
        {
            ProviderController provController = new ProviderController();
            var provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Individual("356566", "individual", "comp", "Spain", 30, "Paðilës 37", true, false);

            double price = 100;
            var providertasks = Substitute.For<Provider>();
            var personTasks = Substitute.For<Individual>();

            providertasks.Login().Returns(provider);
            providertasks.getPrice().Returns(100);
            personTasks.GetPerson().Returns(client);

            double PVM = provController.WriteInvoiceIndividual(providertasks, personTasks);

            Assert.Equal(21, PVM, 0);
        }
        [Fact]
        public void ProviderControler_WriteInvoiceIndividual_Provider_is_VAT_Payer_Client_Lives_EU_IS_VAT_Payer_Diffirent_Country_Return_0()
        {
            ProviderController provController = new ProviderController();
            var provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Individual("356566", "individual", "JA klientas", "Spain", 30, "Paðilës 37", true, true);

            double price = 100;


            var providertasks = Substitute.For<Provider>();
            var personTasks = Substitute.For<Individual>();

            providertasks.Login().Returns(provider);
            providertasks.getPrice().Returns(100);
            personTasks.GetPerson().Returns(client);

            double PVM = provController.WriteInvoiceIndividual(providertasks, personTasks);

            Assert.Equal(0, PVM, 0);
        }
        [Fact]
        public void ProviderControler_WriteInvoiceIndividual_Provider_is_VAT_Payer_Lives_Same_Country_Return_21()
        {
            ProviderController provController = new ProviderController();
            var provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", true);

            var client = new Individual("356566", "individual", "JA klientas", "Lithuania", 21, "Paðilës 37", true, true);

            double price = 100;


            var providertasks = Substitute.For<Provider>();
            var personTasks = Substitute.For<Individual>();

            providertasks.Login().Returns(provider);
            providertasks.getPrice().Returns(100);
            personTasks.GetPerson().Returns(client);

            double PVM = provController.WriteInvoiceIndividual(providertasks, personTasks);

            Assert.Equal(21, PVM, 0);
        }



    }
    */
    }
}
