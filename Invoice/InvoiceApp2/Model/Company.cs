using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApp2.Model
{
	public class Company : Client
	{
        public string clientCode { get; set; }
        public string clientType { get; set; }
    public Company(string clientCode, string clientType, string name, string country, int countryVAT, string adress, bool europeanUnion, bool PVMPayer)
            : base(name, country, countryVAT, adress, europeanUnion, PVMPayer)     
        {
            this.clientCode = clientCode;
            this.clientType = clientType;
            
        }

}
	
}
