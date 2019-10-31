using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Invoice.Models
{
	public class Client
	{
        /*   private string name;

           private Invoice invoices;

           private string country;

           private int countryVAT;

           private bool europeanUnion;

           private string adress;*/

        //private string clientCode;
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
           // this.clientCode = clientCode;
            this.europeanUnion = europeanUnion;
            this.PVMPayer = PVMPayer;
        }

      
       


    }
	
}
