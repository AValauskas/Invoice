using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApp2.Model
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

    }
	
}
