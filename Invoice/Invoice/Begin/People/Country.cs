using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Country
    {
        private string name { get; set; }
      //  private int VAT { get; set; }
        public Country(string name)
        {
            this.name = name;
           // this.VAT = VAT;
        }

        public string GetName()
        {
            return this.name;
        }

       /* public int GetVAT()
        {
            return this.VAT;
        }*/
    }
}
