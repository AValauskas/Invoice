using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Models
{
	public class Individual : Client
	{
        public string clientCode;
        public  string clientType;
        public Individual(string clientCode, string clientType, string name, string country, int countryVAT, string adress, bool europeanUnion, bool PVMPayer)
            : base(name, country, countryVAT, adress, europeanUnion, PVMPayer)
        {
            this.clientCode = clientCode;
            this.clientType = clientType;

        }

        public Individual() { }
        public virtual Individual GetPerson()
        {

            var client = new Individual("356566", "Individual", "Manuel", "Spain", 30, "arias 37", false, true);

            return client;
        }

    }
	
}
