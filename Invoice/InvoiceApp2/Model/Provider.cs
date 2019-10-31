using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApp2.Model
{
	public class Provider
	{
		InvoiceW invoices;

        /*private string name;

        private string country;

        private int countryVAT;

        private string adress;

        private string providerCode;

        private string VATPayer;*/


        public string name { get; set; }

        public string country { get; set; }

        public int countryVAT { get; set; }

        public string adress { get; set; }

        public string providerCode { get; set; }

        public bool VATPayer { get; set; }



        public Provider(string name, string country, int countryVAT, string adress, string providerCode, bool VATPayer)
        {
            this.name = name;
            this.country = country;
            this.countryVAT = countryVAT;
            this.adress = adress;
            this.providerCode = providerCode;
            this.VATPayer = VATPayer;
        }


		
	}
	
}
