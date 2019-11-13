using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Provider:Person
    {
        public Provider(string name, Country country, Company company) : base(name, country, company)
        { 
        
        }
        public Provider() { }
    }
}
