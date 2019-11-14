using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Provider:Person
    {
        public Provider(Country country, Company company) : base(country, company)
        { 
        
        }
        public Provider() { }
    }
}
