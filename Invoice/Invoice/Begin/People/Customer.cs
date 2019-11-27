using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public class Customer
    {
        private string name;
        private Country country;
        private Company company;
        public Customer(Country country, Company company)
        {
            this.country = country;
            this.company = company;
        }

        public Customer(string name, Country country)
        {
            this.country = country;
            this.name = name;
            this.company = null;
        }

        public string Name
        {
            get { return this.name; }
        }

        public Country Country
        {
            get { return this.country; }

        }
        public Company Company
        {
            get { return this.company; }
        }
    }
}
