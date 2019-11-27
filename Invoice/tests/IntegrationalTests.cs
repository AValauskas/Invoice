using System;
using Xunit;
//using Invoice.Begin.Invoice;
using Invoice.Begin.Calculate;
using Invoice.Begin.People;
using Invoice.Begin.Union;
using NSubstitute;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Invoice.Begin;

namespace oneMoreTesting
{
    public class IntegrationalTests 
    {

        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_outside_EU_return_50()
        {

            var calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomLT;
            var customer = UsersFixture.CustomerOutsideEUZE;
            var order = new Order(50);
            IVatGetter vat = new VATGetter();
            ICountryInfoProvider countryprovider = new CountryInfoProvider();
            calculator.CountryProvider = countryprovider;
            calculator.VATGetter = vat;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(50, result);           
        }
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_Dont_pay_VAT_Different_countries_return_121()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomLT;
            var customer = UsersFixture.CustomerInEUSE;
            var order = new Order(100);

            IVatGetter vat = new VATGetter();
            ICountryInfoProvider countryprovider = new CountryInfoProvider();
            calculator.CountryProvider = countryprovider;
            calculator.VATGetter = vat;


            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(121, result);
        }
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Different_countries_return_1000()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomLT;
            var customer = UsersFixture.CustomerInEUSEPayVAT;
            var order = new Order(1000);

            IVatGetter vat = new VATGetter();
            ICountryInfoProvider countryprovider = new CountryInfoProvider();
            calculator.CountryProvider = countryprovider;
            calculator.VATGetter = vat;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(1000, result);
        }
        [Fact]
        public void Provider_IS_VAT_Payer_Client_lives_IN_EU_pay_VAT_Same_countries_return_1210()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomLT;
            var customer = UsersFixture.CustomerInEULTPayVAT;
            var order = new Order(1000);

            IVatGetter vat = new VATGetter();
            ICountryInfoProvider countryprovider = new CountryInfoProvider();
            calculator.CountryProvider = countryprovider;
            calculator.VATGetter = vat;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(1210, result);
        }
        [Fact]
        public void Provider_IS_VAT_Payer_JAV_Client_lives_EU_pay_VAT_Same_countries_return_1210()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomJAV;
            var customer = UsersFixture.CustomerInEUSE;
            var order = new Order(1000);

            IVatGetter vat = new VATGetter();
            ICountryInfoProvider countryprovider = new CountryInfoProvider();
            calculator.CountryProvider = countryprovider;
            calculator.VATGetter = vat;

            var result = calculator.Calculate(customer, provider, order);
            Assert.Equal(11100, result);
        }
        [Fact]
        public void ICalculator_InTerface_Customer_VAT_NOT_fount()
        {
            IInvoiceCalculator calculator = new InvoiceCalculator();

            var provider = UsersFixture.ProviderIsVATPayerFomJAV;
            var customer = UsersFixture.CustomerNotInList;
            var order = new Order(6000);

            ICountryInfoProvider mockIsInEuropeanUnion = new CountryInfoProvider();
            calculator.CountryProvider = mockIsInEuropeanUnion;

            IVatGetter mockVatGetter = new VATGetter();
            calculator.VATGetter = mockVatGetter;

            var message = "VAT were not found, edit your Country VAT list";

            var exception = Assert.Throws<BussinessException>(() => calculator.Calculate(customer, provider, order));
            Assert.Equal(message, exception.Message);
        }

    }
}
