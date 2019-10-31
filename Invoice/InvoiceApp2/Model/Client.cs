using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InvoiceApp2.Model
{
	public class Client
	{
        public string name { get; set; }

        public string country { get; set; }

        public int countryVAT { get; set; }

        public string adress { get; set; }

        public bool europeanUnion { get; set; }

        public bool PVMPayer { get; set; }


        public Client() { }
        public Client(string name, string country, int countryVAT, string adress, bool europeanUnion, bool PVMPayer)
        {
            this.name = name;
            this.country = country;
            this.countryVAT = countryVAT;
            this.adress = adress;
            this.europeanUnion = europeanUnion;
            this.PVMPayer = PVMPayer;
        }


    }
	
}
