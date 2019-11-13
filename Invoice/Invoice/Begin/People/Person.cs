using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Begin.People
{
    public abstract class Person
    {
        private string name;

        private Country country;

        private Company company;
        // private bool IsVatPayer { get; set; }
        public Person(string name, Country country, Company company)
        {
            this.name = name;
            this.country = country;
            this.company = company;
            //this.IsVatPayer = isVatPayer;
        }
        public Person(string name, Country country)
        {
            this.name = name;
            this.country = country;
            this.company = null;
            //  this.IsVatPayer = isVatPayer;
        }
        public Person(){}
        public string GetName()
        {
            return this.name;
        }
        public Country GetCountry()
        {
            return this.country;
        }
        public Company GetCompany()
        {
            return this.company;
        }
    /*    public bool GetIsVatPayer()
        {
            return this.IsVatPayer;
        }*/


    }
}
