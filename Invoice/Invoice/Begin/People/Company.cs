using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Company
    {
        public string name { get; set; }

        public Company(string name)
        {
            this.name = name;
        }
    }
}
