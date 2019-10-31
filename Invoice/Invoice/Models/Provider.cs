using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Invoice.Models
{
    public class Provider
    {
        //  private InvoiceDb db = new MydataEntities1();


        InvoiceW invoices;

        public string name { get; set; }

        public string country { get; set; }

        public int countryVAT { get; set; }

        public string adress { get; set; }

        public string providerCode { get; set; }

        public bool VATPayer { get; set; }

        public Provider() { }


        public Provider(string name, string country, int countryVAT, string adress, string providerCode, bool VATPayer)
        {
            this.name = name;
            this.country = country;
            this.countryVAT = countryVAT;
            this.adress = adress;
            this.providerCode = providerCode;
            this.VATPayer = VATPayer;
        }


        public virtual Provider Login()
        {
            string username = "username";
            string password = "password";



            var provider = new Provider("UAB provider", "Lithuania", 21, "Vilnius", "2336659952", true);

            return provider;
        }

        public virtual double getPrice()
            {
            return 10;
        }

    }
	
}
