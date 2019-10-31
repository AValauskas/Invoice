using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Models
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

        public Company() { }
        public virtual Company GetCompany() {

            var client = new Company("356566", "Company", "UAB corp", "Spain", 30, "gonzaghes 37", false, true);

            return client;
        }

    }
	
}
