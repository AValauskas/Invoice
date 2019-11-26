using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Company
    {
        public string name { get; set; }
        private bool ISVAT { get; set; }

        public Company(string name, bool ISVAT)
        {
            this.name = name;
            this.ISVAT = ISVAT;
        }
        public bool GetIFVAT()
        {
            return this.ISVAT;
        }
    }
}
