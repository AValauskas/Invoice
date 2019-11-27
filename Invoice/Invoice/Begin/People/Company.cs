using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Company
    {
        public string Name { get; set; }
        private bool ISVAT { get; set; }

        public Company(string name, bool ISVAT)
        {
            
            if (name == null)
            { throw new BussinessException("Given Company name is null"); }
            if (ISVAT == null)
            { throw new BussinessException("IT is unclear if Company is Vat payer"); }
            this.Name = name;
            this.ISVAT = ISVAT;
        }
        public bool IsVAT
        {
          get{  return this.ISVAT;}
        }
    }
}
