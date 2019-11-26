using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public abstract class Person
    {
        private Country country;

        private Company company;
        public Person(Country country, Company company)
        {
            
            this.country = country;
            this.company = company;
        }
        public Person(Country country)
        {
           
            this.country = country;
            this.company = null;
        }
        public Country GetCountry()
        {
            return this.country;
        }
        public Company GetCompany()
        {
            return this.company;
        }


    }
}
