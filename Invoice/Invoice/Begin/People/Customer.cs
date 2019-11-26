using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Customer : Person
    {
        private string name;
        public Customer(Country country, Company company) : base(country, company)
        {
        }

        public Customer(string name, Country country) : base(country)
        {
            this.name = name;
        }

        public string GetName() {
            return this.name;
        }
    }
}
