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
            ProviderController provController = new ProviderController();

            var provider = new Provider("UAB tiekëjas", "Lithuania", 21, "Kaunas", "326461131313", false);

            var client = new Company("356566", "company", "uab Rab", "Spain", 30, "37", true, true);

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
}
